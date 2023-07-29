using Global.EF;

namespace OnApp.DataLayer.Repository
{
    public interface IRegionRepository :
        IBaseEntityRepository<int, Region, CreateRegionDlDto, UpdateRegionDlDto>
    {
        Region ByWbCode(string wbCode);
        Region ByRoamingCode(string roamingCode);
    }
}
