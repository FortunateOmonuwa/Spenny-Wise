namespace Spenny_Wise.WebAPI.Domain.DTOs.AuthDTO
{
    public class RegistrationDTO
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty ;
        public string ConfirmPassword { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;

    }
}
