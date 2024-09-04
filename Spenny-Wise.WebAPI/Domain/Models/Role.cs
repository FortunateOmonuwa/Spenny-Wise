using Spenny_Wise.WebAPI.Domain.Models.BaseModelEntity;

namespace Spenny_Wise.WebAPI.Domain.Models
{
    public class Role : BaseEntity
    {
        public List<UserRole> UserRoles { get; set; }
    }
}
