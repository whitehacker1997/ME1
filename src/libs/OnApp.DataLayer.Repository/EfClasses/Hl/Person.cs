using Global.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnApp.DataLayer.Repository
{
    [Table("hl_person")]
    public class Person : 
        IHaveIdProp<int>,
        IHaveStateId
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("pinfl")]
        [StringLength(14)]
        public string? Pinfl { get; set; }
        [Column("inn")]
        [StringLength(9)]
        public string? Inn { get; set; }
        [Column("document_type_id")]
        public int DocumentTypeId { get; set; }
        [Column("document_seria")]
        [StringLength(50)]
        public string DocumentSeria { get; set; } = null!;
        [Column("document_number")]
        [StringLength(50)]
        public string DocumentNumber { get; set; } = null!;
        [Column("document_start_on", TypeName = "timestamp without time zone")]
        public DateTime? DocumentStartOn { get; set; }
        [Column("document_end_on", TypeName = "timestamp without time zone")]
        public DateTime? DocumentEndOn { get; set; }
        [Column("last_name")]
        [StringLength(100)]
        public string LastName { get; set; } = null!;
        [Column("first_name")]
        [StringLength(100)]
        public string FirstName { get; set; } = null!;
        [Column("middle_name")]
        [StringLength(100)]
        public string? MiddleName { get; set; }
        [Column("birth_on", TypeName = "timestamp without time zone")]
        public DateTime BirthOn { get; set; }
        [Column("gender_id")]
        public int? GenderId { get; set; }
        [Column("birth_country_id")]
        public int? BirthCountryId { get; set; }
        [Column("birth_region_id")]
        public int? BirthRegionId { get; set; }
        [Column("birth_district_id")]
        public int? BirthDistrictId { get; set; }
        [Column("citizenship_id")]
        public int? CitizenshipId { get; set; }
        [Column("living_region_id")]
        public int? LivingRegionId { get; set; }
        [Column("living_district_id")]
        public int? LivingDistrictId { get; set; }
        [Column("state_id")]
        public int StateId { get; set; }
        [Column("created_at", TypeName = "timestamp without time zone")]
        public DateTime CreatedAt { get; set; }
        [Column("created_by")]
        public int? CreatedBy { get; set; }
        [Column("modified_at", TypeName = "timestamp without time zone")]
        public DateTime? ModifiedAt { get; set; }
        [Column("modified_by")]
        public int? ModifiedBy { get; set; }



        [ForeignKey(nameof(BirthCountryId))]
        public virtual Country? BirthCountry { get; set; }
        [ForeignKey(nameof(BirthDistrictId))]
        public virtual District? BirthDistrict { get; set; }
        [ForeignKey(nameof(BirthRegionId))]
        public virtual Region? BirthRegion { get; set; }
        [ForeignKey(nameof(CitizenshipId))]
        public virtual Citizenship? Citizenship { get; set; }
        [ForeignKey(nameof(DocumentTypeId))]
        public virtual DocumentType DocumentType { get; set; } = null!;
        [ForeignKey(nameof(GenderId))]
        public virtual Gender? Gender { get; set; }
        [ForeignKey(nameof(LivingDistrictId))]
        public virtual District? LivingDistrict { get; set; }
        [ForeignKey(nameof(LivingRegionId))]
        public virtual Region? LivingRegion { get; set; }
        [ForeignKey(nameof(StateId))]
        public virtual State State { get; set; } = null!;

        public string FullName => $"{LastName} {FirstName} {MiddleName}";
        public string DocumentInfo => $"{DocumentSeria}{DocumentNumber}";
    }
}
