using Global.EF;

namespace OnApp.DataLayer.Repository
{
    public interface IDistrictRepository :
        IBaseEntityRepository<int, District, CreateDistrictDlDto, UpdateDistrictDlDto>
    {
        District ByWbCode(string wbCode);
        District ByRoamingCode(string roamingCode);
    }
}
