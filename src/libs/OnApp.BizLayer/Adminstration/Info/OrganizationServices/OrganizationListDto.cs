using OnApp.DataLayer.Repository;
using GenericServices;

namespace OnApp.BizLayer.OrganizationServices
{
    public class OrganizationListDto : 
        ILinkToEntity<Organization>
    {

        public int Id { get; set; }
        public string? OrderCode { get; set; }
        public string ShortName { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string? Inn { get; set; }
        public int StateId { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Director { get; set; }
        public string? ParentName { get; set; } = null!;
        public string? Latitude { get; set; }
        public string? Longitude { get; set; }
        public string StateName { get; set; } = null!;
        public string CountryName { get; set; } = null!;
        public string RegionName { get; set; } = null!;
        public string DistrictName { get; set; } = null!;
    }
}
