using OnApp.DataLayer.Repository;
using GenericServices;

namespace OnApp.BizLayer.RegionServices
{
    public class RegionDto :
        UpdateRegionDlDto,
        ILinkToEntity<Region>
    {
        public string StateName { get; set; } = null!;
        public string CountryName { get; set; } = null!;
        //new public List<RegionTranslateDto> Translates { get; set; } = new();
    }
}
