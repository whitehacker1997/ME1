using Global.EF;

namespace OnApp.DataLayer.Repository
{
    public interface ICountryRepository :
        IBaseEntityRepository<int, Country, CreateCountryDlDto, UpdateCountryDlDto>
    {
        Country ByWbCode(string wbCode);
    }
}
