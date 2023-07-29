using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OnApp.DataLayer.PgSql
{
    [Table("info_citizenship")]
    public partial class InfoCitizenship
    {
        public InfoCitizenship()
        {
            HlPeople = new HashSet<HlPerson>();
            InfoCitizenshipTranslates = new HashSet<InfoCitizenshipTranslate>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("wb_code")]
        [StringLength(50)]
        public string? WbCode { get; set; }
        [Column("short_name")]
        [StringLength(250)]
        public string ShortName { get; set; } = null!;
        [Column("full_name")]
        [StringLength(250)]
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
        [InverseProperty("InfoCitizenships")]
        public virtual EnumState State { get; set; } = null!;
        [InverseProperty("Citizenship")]
        public virtual ICollection<HlPerson> HlPeople { get; set; }
        [InverseProperty("Owner")]
        public virtual ICollection<InfoCitizenshipTranslate> InfoCitizenshipTranslates { get; set; }
    }
}
