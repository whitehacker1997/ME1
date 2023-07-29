using OnApp.DataLayer.Repository;
using GenericServices;

namespace OnApp.BizLayer.PersonServices
{
    public class PersonDto : 
        CreatePersonDlDto,
        ILinkToEntity<Person>
    {
        public string StateName { get; internal set; } = null!;
        public string DocumentTypeName { get; set; } = null!;
        public string GenderName { get; set; } = null!;
        public string? CitizenshipName { get; set; }
        public string? BirthCountry { get; set; }
        public string FullName { get; set; } = null!;
        public string? LivingRegionName { get; set; }
        public string? LivingDistrictName { get; set; }
    }
}
