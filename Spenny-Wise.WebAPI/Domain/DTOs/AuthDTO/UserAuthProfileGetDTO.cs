using System.ComponentModel.DataAnnotations.Schema;

namespace Spenny_Wise.WebAPI.Domain.DTOs.AuthDTO
{
    public class UserAuthProfileGetDTO
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public byte[] Passwordhash { get; set; }
        public byte[] PasswordSalt { get; set; }
        
        public bool IsVerified { get; set; }
        public string VerifiedAt { get; set; }
        public string VerificationStatus { get; set; }
    
        public Guid UserId { get; set; }
        public string Name { get; set; }
    }
}
