using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OnApp.DataLayer.PgSql
{
    [Table("enum_state_translate")]
    public partial class EnumStateTranslate
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("owner_id")]
        public int OwnerId { get; set; }
        [Column("language_id")]
        public int LanguageId { get; set; }
        [Column("column_name")]
        [StringLength(100)]
        public string ColumnName { get; set; } = null!;
        [Column("translate_text")]
        public string TranslateText { get; set; } = null!;
        [Column("created_at", TypeName = "timestamp without time zone")]
        public DateTime CreatedAt { get; set; }

        [ForeignKey("LanguageId")]
        [InverseProperty("EnumStateTranslates")]
        public virtual EnumLanguage Language { get; set; } = null!;
        [ForeignKey("OwnerId")]
        [InverseProperty("EnumStateTranslates")]
        public virtual EnumState Owner { get; set; } = null!;
    }
}
