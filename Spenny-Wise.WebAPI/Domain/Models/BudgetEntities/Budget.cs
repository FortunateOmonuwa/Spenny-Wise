using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Spenny_Wise.API.Domain.Enums;
using Spenny_Wise.WebAPI.Domain.Models.BaseModelEntity;
using Spenny_Wise.WebAPI.Domain.Models.UserEntity;

namespace Spenny_Wise.WebAPI.Domain.Models.BudgetEntities
{
    public class Budget : BaseEntity
    {
        [Required]
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        [Column(TypeName = "nvarchar(150)")]
        [DisplayName("Description")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Description is required!")]
        [StringLength(maximumLength: 200, MinimumLength = 20, ErrorMessage = "Description has to be between 20 and 200 characters")]
        public string Description { get; set; } = string.Empty;
        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; }

        public LevelOfImportance Importance { get; set; }

        [ForeignKey(nameof(BudgetCategory))]
        public Guid CategoryId { get; set; }
        public List<BudgetItem> BudgetItems { get; set; } = [];
    }
}