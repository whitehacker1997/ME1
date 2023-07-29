using OnApp.DataLayer.Repository;
using GenericServices;

namespace OnApp.BizLayer.RoleServices
{
    public class RoleDto : 
        UpdateRoleDlDto,
        ILinkToEntity<Role>
    {
        public string State { get; internal set; }
        new public List<RoleTranslateDto> Translates { get; set; } = new();
    }
}
