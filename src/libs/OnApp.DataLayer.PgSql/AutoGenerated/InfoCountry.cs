using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OnApp.DataLayer.PgSql
{
    [Table("info_country")]
    [Index("Code", Name = "info_country_unique_code", IsUnique = true)]
    [Index("TextCode", Name = "info_country_unique_text_code", IsUnique = true)]
    public partial class InfoCountry
    {
        public InfoCountry()
        {
            HlPeople = new HashSet<HlPerson>();
            InfoCountryTranslates = new HashSet<InfoCountryTranslate>();
            InfoOrganizations = new HashSet<InfoOrganization>();
            InfoRegions = new HashSet<InfoRegion>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("order_code")]
        [StringLength(10)]
        public string? OrderCode { get; set; }
        [Column("code")]
        [StringLength(10)]
        public string Code { get; set; } = null!;
        [Column("text_code")]
        [StringLength(50)]
        public string TextCode { get; set; } = null!;
        [Column("short_name")]
        [StringLength(250)]
        public string ShortName { get; set; } = null!;
        [Column("full_name")]
        [StringLength(500)]
        public string FullName { get; set; } = null!;
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

        [ForeignKey("StateId")]
        [InverseProperty("InfoCountries")]
        public virtual EnumState State { get; set; } = null!;
        [InverseProperty("BirthCountry")]
        public virtual ICollection<HlPerson> HlPeople { get; set; }
        [InverseProperty("Owner")]
        public virtual ICollection<InfoCountryTranslate> InfoCountryTranslates { get; set; }
        [InverseProperty("Country")]
        public virtual ICollection<InfoOrganization> InfoOrganizations { get; set; }
        [InverseProperty("Country")]
        public virtual ICollection<InfoRegion> InfoRegions { get; set; }
    }
}
