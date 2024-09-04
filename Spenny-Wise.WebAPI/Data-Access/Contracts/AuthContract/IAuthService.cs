using Elastic.CommonSchema;
using Spenny_Wise.WebAPI.Domain.DTOs.AuthDTO;
using Spenny_Wise.WebAPI.Domain.DTOs.UserDTO;
using Spenny_Wise.WebAPI.Domain.Utilities;

namespace Spenny_Wise.WebAPI.Data_Access.Contracts.AuthContract
{
    public interface IAuthService
    {
        Task<ResponseDetail<UserGetDTO>> Register(RegistrationDTO register_model);
        Task<ResponseDetail<string>> VerifyAccount(string token);
        Task<ResponseDetail<LoginResponseDTO>> Login(LoginDTO register_model);
    }
}
