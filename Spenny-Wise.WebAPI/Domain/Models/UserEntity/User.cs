using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Spenny_Wise.WebAPI.Domain.Models.BaseModelEntity;
using Spenny_Wise.WebAPI.Domain.Models.BudgetEntities;
using Spenny_Wise.WebAPI.Domain.Models.ExpenseEntities;

namespace Spenny_Wise.WebAPI.Domain.Models.UserEntity
{
    public class User : BaseEntity
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string MiddleName { get; set; } = "";
        [DisplayName("Phone-Number")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Phone-Number is required!")]
        [DataType(DataType.EmailAddress)]
        public string PhoneNumber { get; set; } = "PhoneNumber";

        [DisplayName("Email")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = "Email";

        public string DateCreated { get; set; } = DateTime.Now.Date.ToShortDateString();
        public List<Budget> Budgets { get; set; } = [];
        public List<Expense> Expenses { get; set; } = [];
        public List<BudgetCategory> BudgetCategories { get; set; } = [];
        public List<ExpenseCategory> ExpenseCategories { get; set; } = [];
        public List<UserRole> UserRoles { get; set; } = [];
    }
}
