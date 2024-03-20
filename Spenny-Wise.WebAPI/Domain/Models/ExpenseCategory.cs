using System.ComponentModel.DataAnnotations.Schema;

namespace Spenny_Wise.WebAPI.Domain.Models
{
    public class ExpenseCategory : BaseEntity
    {
        [ForeignKey(nameof(User))]
        public int? UserId { get; set; }
    }
}