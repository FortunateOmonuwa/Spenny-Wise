using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spenny_Wise.WebAPI.Domain.Models.BaseModelEntity
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name is required!")]
        [StringLength(maximumLength: 150, MinimumLength = 3, ErrorMessage = "Name has to be between 3 and 150 characters")]
        [Column(TypeName = "nvarchar(150)")]
        [DisplayName("Name")]
        public string Name { get; set; } = "Enter Name";

    }
}
