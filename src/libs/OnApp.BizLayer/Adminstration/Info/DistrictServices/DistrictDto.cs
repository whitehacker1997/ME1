using OnApp.DataLayer.Repository;
using GenericServices;

namespace OnApp.BizLayer.DistrictServices
{
    public class DistrictDto :
        UpdateDistrictDlDto,
        ILinkToEntity<District>
    {
        public string StateName { get; set; } = null!;
        public string RegionName { get; set; } = null!;
        //new public List<DistrictTranslateDto> Translates { get; set; } = new();
    }
}
