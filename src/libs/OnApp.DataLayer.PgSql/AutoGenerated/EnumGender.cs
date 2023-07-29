using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OnApp.DataLayer.PgSql
{
    [Table("enum_gender")]
    public partial class EnumGender
    {
        public EnumGender()
        {
            EnumGenderTranslates = new HashSet<EnumGenderTranslate>();
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
        [StringLength(500)]
        public string FullName { get; set; } = null!;
        [Column("created_at", TypeName = "timestamp without time zone")]
        public DateTime? CreatedAt { get; set; }

        [InverseProperty("Owner")]
        public virtual ICollection<EnumGenderTranslate> EnumGenderTranslates { get; set; }
        [InverseProperty("Gender")]
        public virtual ICollection<HlPerson> HlPeople { get; set; }
    }
}
