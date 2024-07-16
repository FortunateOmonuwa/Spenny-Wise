using Spenny_Wise.WebAPI.Domain.Models.BaseModelEntity;
using Spenny_Wise.WebAPI.Domain.Models.UserEntity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spenny_Wise.WebAPI.Domain.Models.ExpenseEntities
{
    public class Expense : BaseEntity
    {
        [DisplayName("Price")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Price is required!")]
        [DataType(DataType.Currency)]
        public string Price { get; set; } = "Price";

        [DataType(DataType.Date)]
        public DateTime DateOfExpense { get; set; }

        [ForeignKey(nameof(ExpenseCategory))]
        public int? CategoryId { get; set; }


        [ForeignKey(nameof(User))]
        public int? UserId { get; set; }



    }
}