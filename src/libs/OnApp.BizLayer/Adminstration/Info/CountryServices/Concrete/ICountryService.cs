using OnApp.DataLayer.Repository;
using Global.Models;
using StatusGeneric;

namespace OnApp.BizLayer.CountryServices
{
    public interface ICountryService :
        IStatusGeneric
    {
        PagedResult<CountryListDto> GetList(SortFilterPageOptions options);
        SelectList<int> GetAsSelectList();
        CountryDto GetCountry();
        CountryDto GetCountryById(int Id);
        HaveId<int> CreateCountry(CreateCountryDlDto dto);
        void UpdateCountry(UpdateCountryDlDto dto);
        void DeleteCountry(int Id);
    }
}
