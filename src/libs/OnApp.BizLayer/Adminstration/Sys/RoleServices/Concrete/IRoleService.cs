using OnApp.DataLayer.Repository;
using Global.Models;
using StatusGeneric;

namespace OnApp.BizLayer.RoleServices
{
    public interface IRoleService :
        IStatusGeneric
    {
        PagedResult<RoleListDto> GetRoleList(SortFilterPageOptions dto);
        RoleDto GetRole();
        RoleDto GetRoleById(int id);
        SelectList<int> GetRoleAsSelectList();
        HaveId<int> CreateRole(CreateRoleDlDto dto);
        void UpdateRole(UpdateRoleDlDto dto);
        void DeleteRole(int id);
    }
}
