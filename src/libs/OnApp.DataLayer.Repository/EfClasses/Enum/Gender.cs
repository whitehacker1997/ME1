using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnApp.DataLayer.Repository
{
    [Table("enum_gender")]
    public class Gender
    {
        public Gender()
        {
            Translates = new HashSet<GenderTranslate>();
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


        [InverseProperty(nameof(GenderTranslate.Owner))]
        public virtual ICollection<GenderTranslate> Translates { get; set; }
    }
}
