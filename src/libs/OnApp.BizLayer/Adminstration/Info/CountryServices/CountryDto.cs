using OnApp.DataLayer.Repository;
using GenericServices;

namespace OnApp.BizLayer.CountryServices
{
    public class CountryDto :
        UpdateCountryDlDto,
        ILinkToEntity<Country>
    {
        public string StateName { get; set; } = null!;
        //public List<CountryTranslateDto> Translates { get; set; } = new();
    }
}
