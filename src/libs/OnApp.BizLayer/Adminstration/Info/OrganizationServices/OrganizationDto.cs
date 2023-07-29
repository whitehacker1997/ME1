using OnApp.DataLayer.Repository;
using GenericServices;

namespace OnApp.BizLayer.OrganizationServices
{
    public class OrganizationDto :
        UpdateOrganizationDlDto,
        ILinkToEntity<Organization>
    {
        public string ShortName { get; set; } = null!;
        public string? ParentName { get; set; } = null!;
        public string StateName { get; set; } = null!;
        public string CountryName { get; set; } = null!;
        public string RegionName { get; set; } = null!;
        public string DistrictName { get; set; } = null!;
        //new public List<OrganizationTranslateDto> Translates { get; set; } = new();
    }
}
