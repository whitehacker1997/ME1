using OnApp.DataLayer.Repository;
using GenericServices;
using Global.Models;

namespace OnApp.BizLayer.PersonServices
{
    public class PersonListDto :
        ILinkToEntity<Person>,
        IHaveIdProp<int>
    {
        public int Id { get; set; }
        public string? Pinfl { get; set; }
        public int DocumentTypeId { get; set; }
        public string DocumentTypeName { get; set; } = null!;
        public string DocumentSeria { get; set; } = null!;
        public string DocumentNumber { get; set; } = null!;
        public DateTime? DocumentStartOn { get; set; }
        public DateTime? DocumentEndOn { get; set; }
        public string FullName { get; set; } = null!;
        public int? GenderId { get; set; }
        public string GenderName { get; set; } = null!;
        public string? LivingRegionName { get; set; }
        public string? LivingDistrictName { get; set; }
        public string? CitizenshipName { get; set; }
        public string? BirthCountry { get; set; }
        public string StateName { get; internal set; } = null!;
    }
}
