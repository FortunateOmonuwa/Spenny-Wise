using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spenny_Wise.WebAPI.Domain.Models
{
    public class BudgetItem : BaseEntity
    {
        [DisplayName("minimum amount it'll cost")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "min amount is required!")]
        [DataType(DataType.Currency)]
        public string MinAmount { get; set; } = "min amount";

        [DisplayName("maximum amount it'll cost")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "max amount is required!")]
        [DataType(DataType.Currency)]
        public string MaxAmount { get; set; } = "max amount";

        [ForeignKey(nameof(Budget))]
        public Guid BudgetId { get; set; }
    }
}