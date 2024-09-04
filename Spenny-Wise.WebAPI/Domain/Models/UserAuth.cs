using Spenny_Wise.WebAPI.Domain.Models.UserEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spenny_Wise.WebAPI.Domain.Models
{
    public class UserAuth
    {
        [Key]
        public Guid Id { get; set; }
        public string Email { get; set; }
        public byte[] Passwordhash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string VerificationToken { get; set; } = string.Empty;
        public string VerificationTokenExpiration { get; set; } = "";
        public bool IsVerified { get; set; }    
        public string VerifiedAt { get; set; } 
        public string VerificationStatus { get; set; }
        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }
        public User User { get; set; }
        public string Name { get; set; }
        public string RefreshToken { get; set; } = string.Empty;
        public string RefreshTokenExpiration { get; set; } = "";
       
        public string DateCreated { get; set; } = DateTime.Now.Date.ToShortDateString();
    }
}
