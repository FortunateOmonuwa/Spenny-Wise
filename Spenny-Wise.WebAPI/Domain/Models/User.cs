using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Spenny_Wise.WebAPI.Domain.Models
{
    public class User : BaseEntity
    {
        [DisplayName("Phone-Number")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Phone-Number is required!")]
        [DataType(DataType.EmailAddress)]
        public string PhoneNumber { get; set; } = "PhoneNumber";

        [DisplayName("Email")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = "Email";

        [Column(TypeName = "nvarchar(150)")]
        [DisplayName("Password")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required!")]
        [StringLength(maximumLength: 100, MinimumLength = 8, ErrorMessage = "Password has to be between 8 and 100 characters")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = "Password";
        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; }
        public List<Budget>? Budgets { get; set; }
        public List<Expense>? Expenses { get; set; }
        public List<BudgetCategory>? Categories { get; set; }
    }
}
