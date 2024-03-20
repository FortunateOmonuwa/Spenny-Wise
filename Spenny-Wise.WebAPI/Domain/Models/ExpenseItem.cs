using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spenny_Wise.WebAPI.Domain.Models
{
    public class ExpenseItem : BaseEntity
    {

        [DisplayName("Price")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Price is required!")]
        [DataType(DataType.Currency)]
        public string Price { get; set; } = "Price";
        [ForeignKey(nameof(Expense))]
        public Guid ExpenseId { get; set; }
    }
}