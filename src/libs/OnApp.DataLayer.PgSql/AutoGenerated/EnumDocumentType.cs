using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OnApp.DataLayer.PgSql
{
    [Table("enum_document_type")]
    public partial class EnumDocumentType
    {
        public EnumDocumentType()
        {
            EnumDocumentTypeTranslates = new HashSet<EnumDocumentTypeTranslate>();
            HlPeople = new HashSet<HlPerson>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("order_code")]
        [StringLength(50)]
        public string? OrderCode { get; set; }
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
        [InverseProperty("EnumDocumentTypes")]
        public virtual EnumState State { get; set; } = null!;
        [InverseProperty("Owner")]
        public virtual ICollection<EnumDocumentTypeTranslate> EnumDocumentTypeTranslates { get; set; }
        [InverseProperty("DocumentType")]
        public virtual ICollection<HlPerson> HlPeople { get; set; }
    }
}
