using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spenny_Wise.WebAPI.Domain.Models
{
    public class Expense : BaseEntity
    {

        [ForeignKey(nameof(ExpenseCategory))]
        public Guid? CategoryId { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfExpense { get; set; }
        [DisplayName("Price")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Price is required!")]
        [DataType(DataType.Currency)]
        public string Price { get; set; } = "Price";

    }
}