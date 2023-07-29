using OnApp.Core;
using Global.Attributes;
using Global.EF;

namespace OnApp.DataLayer.Repository
{
    public class PersonDlDto<TDto> :
        EntityDto<TDto, Person>
            where TDto : PersonDlDto<TDto>
    {
        [LocalizedStringLength(14)]
        public string? Pinfl { get; set; }
        [LocalizedStringLength(9)]
        public string? Inn { get; set; }
        [LocalizedRequired]
        public int DocumentTypeId { get; set; }
        [LocalizedRequired]
        [LocalizedStringLength(50)]
        public string DocumentSeria { get; set; } = null!;
        [LocalizedRequired]
        [LocalizedStringLength(50)]
        public string DocumentNumber { get; set; } = null!;
        public DateTime? DocumentStartOn { get; set; }
        public DateTime? DocumentEndOn { get; set; }
        [LocalizedRequired]
        [LocalizedStringLength(100)]
        public string LastName { get; set; } = null!;
        [LocalizedRequired]
        [LocalizedStringLength(100)]
        public string FirstName { get; set; } = null!;
        [LocalizedRequired]
        [LocalizedStringLength(100)]
        public string? MiddleName { get; set; } = null!;
        [LocalizedRequired]
        public DateTime BirthOn { get; set; }
        [LocalizedRequired]
        public int? GenderId { get; set; }
        public int? BirthCountryId { get; set; }
        public int? BirthRegionId { get; set; }
        public int? BirthDistrictId { get; set; }
        public int? CitizenshipId { get; set; }
        public int? LivingRegionId { get; set; }
        public int? LivingDistrictId { get; set; }


        public override Person CreateEntity()
        {
            var entity = base.CreateEntity();
            entity.StateId = StateIdConst.ACTIVE;

            return entity;
        }
    }
}
