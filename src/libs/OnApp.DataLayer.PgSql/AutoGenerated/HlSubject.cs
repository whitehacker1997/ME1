using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OnApp.DataLayer.PgSql
{
    [Table("hl_subject")]
    [Index("Code", Name = "hl_subject_unique_index_code", IsUnique = true)]
    public partial class HlSubject
    {
        public HlSubject()
        {
            HlSubjectTranslates = new HashSet<HlSubjectTranslate>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("code")]
        [StringLength(50)]
        public string Code { get; set; } = null!;
        [Column("order_code")]
        [StringLength(50)]
        public string? OrderCode { get; set; }
        [Column("short_name")]
        [StringLength(500)]
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
        [InverseProperty("HlSubjects")]
        public virtual EnumState State { get; set; } = null!;
        [InverseProperty("Owner")]
        public virtual ICollection<HlSubjectTranslate> HlSubjectTranslates { get; set; }
    }
}
