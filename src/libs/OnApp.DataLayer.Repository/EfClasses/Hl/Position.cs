using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Global.Models;
using Microsoft.EntityFrameworkCore;

namespace OnApp.DataLayer.Repository
{
    [Table("hl_position")]
    [Index("Code", Name = "hl_position_unique_index_code", IsUnique = true)]
    public class Position :
        IHaveStateId,
        IHaveIdProp<int>
    {
        public Position()
        {
            Translates = new HashSet<PositionTranslate>();
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
        [Column("is_doctor")]
        public bool IsDoctor { get; set; }
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
        [InverseProperty(nameof(PositionTranslate.Owner))]
        public virtual ICollection<PositionTranslate> Translates { get; set; }
    }
}
