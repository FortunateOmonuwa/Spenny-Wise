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

        public string DateOfExpense { get; set; } = DateTime.Now.Date.ToShortDateString();

        [ForeignKey(nameof(ExpenseCategory))]
        public int CategoryId { get; set; }


        [ForeignKey(nameof(User))]
        public Guid? UserId { get; set; }



    }
}