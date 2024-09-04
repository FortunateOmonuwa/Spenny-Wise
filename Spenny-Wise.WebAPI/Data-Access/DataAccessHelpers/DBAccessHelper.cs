using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Spenny_Wise.WebAPI.Domain.DTOs.AuthDTO;
using Spenny_Wise.WebAPI.Domain.DTOs.UserDTO;
using Spenny_Wise.WebAPI.Domain.Models.ExpenseEntities;
using Spenny_Wise.WebAPI.Domain.Models.UserEntity;

namespace Spenny_Wise.WebAPI.Data_Access.DataAccessHelpers
{
    public class DBAccessHelper
    {
        private readonly SpennyContext context;
        private readonly IMemoryCache memoryCache;
        //  private readonly ILogger<DBAccessHelper> logger = logger;

        public DBAccessHelper(ILogger<DBAccessHelper> logger, SpennyContext context, IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
            this.context = context;
        }


        public async Task<bool> CheckUserEmail(string email)
        {
            try
            {
                var user = await context.Users.AnyAsync(x => x.Email == email);
                if (user)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                

            }
            catch
            {
                throw;
            }

        }
        public async Task<User> GetUserWithProps(string user_id)
        {
            try
            {
                var user = await context.Users
                                .Include(x => x.Budgets)
                                .Include(x => x.Expenses)
                                .Include(x => x.BudgetCategories)
                                .Include(x => x.ExpenseCategories)
                                .FirstOrDefaultAsync(x => x.Id.ToString() == user_id);

                if (user is not null)
                {
                   // logger.LogInformation("User was successfully retrieved from the database");
                    return user;

                }
                else
                {
                    // logger.LogError("User was not found on the database");
                    throw new NullReferenceException("User is null");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.GetType().Name} \n\n\n {ex.Message} \n\n\n {ex.Source}");
            }

        }

        public async Task<List<UserGetWithEmail>> GetAllUsersEmail()
        {
            try
            {
                var cacheKey = "AllUsersEmail";

                if (memoryCache.TryGetValue(cacheKey, out List<UserGetWithEmail> users))
                {
                    return users;
                }

                users = await context.Users
                    .Select(x => new UserGetWithEmail
                    {
                        Email = x.Email,
                    })
                    .ToListAsync();

                var entryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(30));

                memoryCache.Set(cacheKey, users, entryOptions);

                return users;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
         
        }

        public async Task<List<UserAuthProfileGetDTO>> GetAllUserProfiles()
        {
            try
            {
                var cacheKey = "AuthProfiles";
                var cache = memoryCache.TryGetValue(cacheKey, out List<UserAuthProfileGetDTO> profiles);
                if (!cache)
                {
                    profiles = await context.UserAuthentication.Select(x => new UserAuthProfileGetDTO
                    {
                        Id = x.Id,
                        UserId = x.UserId,
                        Name = x.Name,
                        Email = x.Email,
                        Passwordhash = x.Passwordhash,
                        PasswordSalt = x.PasswordSalt,
                        IsVerified = x.IsVerified,
                     
                        VerificationStatus = x.VerificationStatus,
                        VerifiedAt = x.VerifiedAt
                    }).ToListAsync();

                    var cacheEntryOptions = new MemoryCacheEntryOptions
                    {
                        SlidingExpiration = TimeSpan.FromMinutes(30)
                    };

                    memoryCache.Set(cacheKey, profiles, cacheEntryOptions);
                    return profiles;
                }

                else
                {
                    return profiles;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<User> GetUser(string user_id)
        {
            try
            {
                var user = await context.Users.FirstOrDefaultAsync(x => x.Id.ToString() == user_id);

                if (user is not null)
                {
                   // logger.LogInformation("User was successfully retrieved from the database");
                    return user;

                }
                else
                {
                    // logger.LogError("User was not found on the database");
                    throw new NullReferenceException("User is null");
                }
            }
            catch (Exception ex)
            {
               // logger.LogError($"{ex.GetType().Name} \n\n\n {ex.Message} \n\n\n {ex.Source}");
                throw new Exception($"{ex.GetType().Name} \n\n\n {ex.Message} \n\n\n {ex.Source}");
            }
        }

        public async Task<ExpenseCategory> GetCategory(int category_id)
        {
            try
            {
                var category =await context.ExpenseCategories.FirstOrDefaultAsync(x => x.Id == category_id);
                if(category is not null)
                {
                    return category;
                }
                else
                {
                    return null;
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
