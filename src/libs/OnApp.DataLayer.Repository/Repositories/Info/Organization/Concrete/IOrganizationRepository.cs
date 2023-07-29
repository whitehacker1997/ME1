using Global.EF;

namespace OnApp.DataLayer.Repository
{
    public interface IOrganizationRepository :
        IBaseEntityRepository<int, Organization, CreateOrganizationDlDto, UpdateOrganizationDlDto>
    {
        Organization ByInn(string inn);
    }
}
