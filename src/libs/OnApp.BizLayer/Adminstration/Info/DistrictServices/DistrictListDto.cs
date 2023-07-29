using OnApp.DataLayer.Repository;
using GenericServices;

namespace OnApp.BizLayer.DistrictServices
{
    public class DistrictListDto : 
        ILinkToEntity<District>
    {

        public int Id { get; set; }
        public string? OrderCode { get; set; }
        public string? Code { get; set; }
        public string? Soato { get; set; }
        public string? RoamingCode { get; set; }
        public string ShortName { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public int StateId { get; set; }
        public string StateName { get; set; } = null!;
        public string RegionName { get; set; } = null!;
    }
}
