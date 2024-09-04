using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Spenny_Wise.WebAPI.Data_Access.Contracts.AuthContract;
using Spenny_Wise.WebAPI.Domain.DTOs.AuthDTO;

namespace Spenny_Wise.WebAPI.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;
        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }

       // [Authorize(Roles = "Admin")]
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegistrationDTO registerModel)
        {
            try
            {
                var res = await authService.Register(registerModel);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("VerifyAccount")]
        public async Task<IActionResult> VerifyAccount(string token)
        {
            try
            {
                var res = await authService.VerifyAccount(token);
                return Ok(res);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginModel)
        {
            try
            {
                var res = await authService.Login(loginModel);
                return Ok(res); 
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
