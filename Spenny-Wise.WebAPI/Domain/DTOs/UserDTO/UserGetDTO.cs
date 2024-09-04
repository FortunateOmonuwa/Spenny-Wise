namespace Spenny_Wise.WebAPI.Domain.DTOs.UserDTO
{
    public class UserGetDTO
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
      //  public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string DateCreated { get; set; }
       // public string VerificationToken { get; set; }
    }
}
