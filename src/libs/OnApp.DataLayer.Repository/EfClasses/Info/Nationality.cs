using Global.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnApp.DataLayer.Repository
{
    [Table("info_nationality")]
    public class Nationality :
        IHaveIdProp<int>,
        IHaveStateId
    {
        public Nationality()
        {
            Translates = new HashSet<NationalityTranslate>();
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

        [ForeignKey(nameof(StateId))]
        public virtual State State { get; set; } = null!;

        [InverseProperty(nameof(NationalityTranslate.Owner))]
        public virtual ICollection<NationalityTranslate> Translates { get; set; }
    }
}
