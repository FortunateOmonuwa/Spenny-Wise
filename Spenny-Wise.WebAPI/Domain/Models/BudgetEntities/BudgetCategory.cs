using Spenny_Wise.WebAPI.Domain.Models.BaseModelEntity;
using Spenny_Wise.WebAPI.Domain.Models.UserEntity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spenny_Wise.WebAPI.Domain.Models.BudgetEntities
{
    public class BudgetCategory : BaseEntity
    {
        [ForeignKey(nameof(User))]
        public int? UserId { get; set; }
    }
}