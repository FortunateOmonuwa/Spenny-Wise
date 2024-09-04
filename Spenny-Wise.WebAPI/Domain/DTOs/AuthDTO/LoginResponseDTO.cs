namespace Spenny_Wise.WebAPI.Domain.DTOs.AuthDTO
{
    public class LoginResponseDTO
    {
        public Guid UserID { get; set; }
        public string? Token { get; set; }
        public string Message { get; set; }
    }
}
