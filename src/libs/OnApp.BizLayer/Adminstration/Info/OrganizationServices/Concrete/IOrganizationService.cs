using OnApp.DataLayer.Repository;
using Global.Models;
using StatusGeneric;

namespace OnApp.BizLayer.OrganizationServices
{
    public interface IOrganizationService : 
        IStatusGeneric
    {
        PagedResult<OrganizationListDto> GetOrganizationList(SortFilterPageOptions options);
        SelectList<int> GetOrganizationAsSelectList();
        OrganizationDto GetOrganization();
        OrganizationDto GetOrganizationById(int organizationId);
        HaveId<int> CreateOrganization(CreateOrganizationDlDto dto);
        void UpdateOrganization(UpdateOrganizationDlDto dto);
        void DeleteOrganization(int organizationId);
    }
}
