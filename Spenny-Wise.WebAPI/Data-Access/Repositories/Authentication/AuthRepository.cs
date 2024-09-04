using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Spenny_Wise.WebAPI.Data_Access.Contracts.AuthContract;
using Spenny_Wise.WebAPI.Data_Access.DataAccessHelpers;
using Spenny_Wise.WebAPI.Domain.DTOs;
using Spenny_Wise.WebAPI.Domain.DTOs.AuthDTO;
using Spenny_Wise.WebAPI.Domain.DTOs.UserDTO;
using Spenny_Wise.WebAPI.Domain.Models;
using Spenny_Wise.WebAPI.Domain.Models.UserEntity;
using Spenny_Wise.WebAPI.Domain.Utilities;
using Spenny_Wise.WebAPI.Service.MailService;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Spenny_Wise.WebAPI.Data_Access.Repositories.Authentication
{
    public class AuthRepository : IAuthService
    {
        private readonly SpennyContext context;
        private readonly DBAccessHelper dBAccessHelper;
        private readonly IMemoryCache memoryCache;
        private readonly TimeSpan _cacheExpiration = TimeSpan.FromMinutes(30);
        private readonly IMailService mailService;
        private readonly AppSettings appSettings;

        public AuthRepository(SpennyContext context, DBAccessHelper dbAccessHelper, IMemoryCache memoryCache, IMailService mailService, IOptions<AppSettings> appSettings)
        {
            this.context = context;
            this.dBAccessHelper = dbAccessHelper;
            this.memoryCache = memoryCache;
            this.mailService = mailService;
            this.appSettings = appSettings.Value;
        }

        public async Task<ResponseDetail<UserGetDTO>> Register(RegistrationDTO register_model)
        {
            using var transaction = await context.Database.BeginTransactionAsync();
            var response = new ResponseDetail<UserGetDTO>();
            try
            {
                var users = await dBAccessHelper.GetAllUsersEmail();
                var registering_user = users.Any(x => x.Email.Equals(register_model.Email, StringComparison.OrdinalIgnoreCase));
                if (registering_user is true)
                {
                    throw new ArgumentException($"User with Email:{register_model.Email} already exists");
                }
                var user = new User
                {
                    Email = register_model.Email.ToUpper(),
                    FirstName = register_model.FirstName.ToUpper(),
                    LastName = register_model.LastName.ToUpper(),
                    MiddleName = register_model.MiddleName.ToUpper(),
                    PhoneNumber = register_model.PhoneNumber,
                    Name = $"{register_model.FirstName.ToUpper()} {register_model.LastName.ToUpper()} {register_model.MiddleName?.ToUpper()}".Trim()
                };

                await context.Users.AddAsync(user);
                await context.SaveChangesAsync();

                EncryptionHandler.EncryptPassword(register_model.Password, out byte[] hash, out byte[] salt);
                var user_auth_profile = new UserAuth
                {
                    Email = user.Email,
                    Name = user.Name,
                    UserId = user.Id,
                    VerificationStatus = "Unverified",
                    Passwordhash = hash,
                    PasswordSalt = salt,
                    VerificationTokenExpiration = DateTime.Now.AddMinutes(15).ToString(),
                    VerificationToken = RandomNumberGenerator.GetInt32(100000, 999999).ToString(),
                    VerifiedAt = ""
                };
                await context.UserAuthentication.AddAsync(user_auth_profile);
                await context.SaveChangesAsync();
                await transaction.CommitAsync();

                var mail = new MailSendDTO
                {
                    Email = user_auth_profile.Email,
                    Subject = "Account Verifcation Required",
                    Body = user_auth_profile.VerificationToken
                };
                mailService.SendRegistrationMail(mail);

                var userGetDTO = new UserGetDTO
                {
                    Id = user.Id,
                    DateCreated = user.DateCreated,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    MiddleName = user.MiddleName,
                    PhoneNumber = user.PhoneNumber,
                   
                };

                response = response.SuccessResultData(userGetDTO);
                       
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
            return response;
        }

        public async Task<ResponseDetail<string>> VerifyAccount(string token)
        {
            try
            {
                var response = new ResponseDetail<string>();
                UserAuth user;
                var cacheKey = "Profiles";
                var cache = memoryCache.TryGetValue(cacheKey, out List<UserAuth> profiles);
                if (!cache)
                {
                    profiles = await context.UserAuthentication
                   .Include(x => x.User)
                   .ThenInclude(x => x.UserRoles)
                   .ThenInclude(x => x.Role)
                   .ToListAsync();
                    var cacheEntryParams = new MemoryCacheEntryOptions
                    {
                        SlidingExpiration = TimeSpan.FromMinutes(10)
                    };
                    memoryCache.Set(cacheKey, profiles, cacheEntryParams);
                    user = profiles.FirstOrDefault(x => x.VerificationToken.Equals(token));
                }
                 user = profiles.FirstOrDefault(x => x.VerificationToken.Equals(token));
                if(user is null)
                {
                    response = response.FailedResultData("Invalid Token");
                }
                else if(DateTime.Now > DateTime.Parse(user.VerificationTokenExpiration))
                {
                    user.VerifiedAt = "";
                    user.VerificationStatus = "Unverified";
                    user.VerificationTokenExpiration = "";
                    user.VerificationToken = "";
                    context.UserAuthentication.Update(user);
                    await context.SaveChangesAsync();
                    response = response.FailedResultData("Expired Token");
                }
                else
                {
                    user.VerifiedAt = DateTime.Now.ToString();
                    user.VerificationStatus = "Verified";
                    user.VerificationTokenExpiration = "";
                    user.VerificationToken = "";
                    user.IsVerified = true;
                    context.UserAuthentication.Update(user);

                    var role = await context.Roles.FirstOrDefaultAsync(x => x.Id.ToString() == appSettings.USERID);
                    var user_role = new UserRole
                    {
                        Role = role,
                        UserId = user.UserId,
                        RoleId = role.Id,
                        User = user.User
                    };
                    //var user_role = new List<UserRole>();
                    //foreach(var role in roles)
                    //{
                    //    var userrole = new UserRole
                    //    {
                    //        Role = role,
                    //        UserId = user.UserId,
                    //        RoleId  = role.Id,
                    //        User = user.User
                    //    };
                    //    user_role.Add(userrole);
                    //}
                   
                    user.User.UserRoles.Add(user_role);
                    await context.SaveChangesAsync();
                    response = response.SuccessResultData("Verification success");
                }
                return response;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ResponseDetail<LoginResponseDTO>> Login(LoginDTO login_model)
        {
            try
            {
                UserAuth user_profile;
                var cacheKey = "Profiles";
                var cache = memoryCache.TryGetValue(cacheKey, out List<UserAuth> profiles);
                if (!cache)
                {
                    profiles = await context.UserAuthentication
                   .Include(x => x.User)
                   .ThenInclude(x => x.UserRoles)
                   .ThenInclude(x => x.Role)
                   .ToListAsync();
                    var cacheEntryParams = new MemoryCacheEntryOptions
                    {
                        SlidingExpiration = TimeSpan.FromMinutes(10)
                    };
                    memoryCache.Set(cacheKey, profiles, cacheEntryParams);
                    user_profile = profiles.FirstOrDefault(x => x.Email.Equals(login_model.Email.ToUpper()));
                }
              
                user_profile = profiles.FirstOrDefault(x => x.Email.Equals(login_model.Email.ToUpper()));
                
                var passwordConfirmation = EncryptionHandler.VerifyPassword(login_model.Password, user_profile.Passwordhash, user_profile.PasswordSalt);
                if(user_profile is null || !passwordConfirmation)
                {
                    throw new ArgumentNullException("Email or Password is Incorrect");
                }
                else if(user_profile.IsVerified == false)
                {
                    throw new UnauthorizedAccessException("Please complete your account verification before you can login");
                }
                var roles = user_profile.User.UserRoles.Select(x => x.Role.Name).ToList();
                
                var claims = new List<Claim>
                {
                     new("Email", login_model.Email),
                     new("Name" , user_profile.Name),
                     new("Id" , user_profile.UserId.ToString()),                    
                };
                foreach (var role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(appSettings.SECRET));
                var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    appSettings.JWT_ISSUER,
                    claims: claims,
                    signingCredentials: credentials,
                    expires: DateTime.Now.AddMinutes(60)
                    );
             
                var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

                var response = new ResponseDetail<LoginResponseDTO>();

                var loginResponse = new LoginResponseDTO
                {
                    Message = "Login Successful",
                    UserID = user_profile.UserId,
                    Token = jwtToken,
                };

                response = response.SuccessResultData(loginResponse);
                return response;
                

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}