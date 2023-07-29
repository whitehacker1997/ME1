using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OnApp.DataLayer.PgSql
{
    [Table("info_region")]
    public partial class InfoRegion
    {
        public InfoRegion()
        {
            HlPersonBirthRegions = new HashSet<HlPerson>();
            HlPersonLivingRegions = new HashSet<HlPerson>();
            InfoDistricts = new HashSet<InfoDistrict>();
            InfoOrganizations = new HashSet<InfoOrganization>();
            InfoRegionTranslates = new HashSet<InfoRegionTranslate>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("order_code")]
        [StringLength(50)]
        public string? OrderCode { get; set; }
        [Column("code")]
        [StringLength(50)]
        public string? Code { get; set; }
        [Column("soato")]
        [StringLength(50)]
        public string? Soato { get; set; }
        [Column("roaming_code")]
        [StringLength(50)]
        public string? RoamingCode { get; set; }
        [Column("short_name")]
        [StringLength(250)]
        public string ShortName { get; set; } = null!;
        [Column("full_name")]
        [StringLength(250)]
        public string FullName { get; set; } = null!;
        [Column("country_id")]
        public int CountryId { get; set; }
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

        [ForeignKey("CountryId")]
        [InverseProperty("InfoRegions")]
        public virtual InfoCountry Country { get; set; } = null!;
        [ForeignKey("StateId")]
        [InverseProperty("InfoRegions")]
        public virtual EnumState State { get; set; } = null!;
        [InverseProperty("BirthRegion")]
        public virtual ICollection<HlPerson> HlPersonBirthRegions { get; set; }
        [InverseProperty("LivingRegion")]
        public virtual ICollection<HlPerson> HlPersonLivingRegions { get; set; }
        [InverseProperty("Region")]
        public virtual ICollection<InfoDistrict> InfoDistricts { get; set; }
        [InverseProperty("Region")]
        public virtual ICollection<InfoOrganization> InfoOrganizations { get; set; }
        [InverseProperty("Owner")]
        public virtual ICollection<InfoRegionTranslate> InfoRegionTranslates { get; set; }
    }
}
