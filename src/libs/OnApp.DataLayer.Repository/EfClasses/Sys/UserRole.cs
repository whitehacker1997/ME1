using Global.EF;
using Global.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnApp.DataLayer.Repository
{
    [Table("sys_user_role")]
    public class UserRole :
        IHaveStateId,
        IHaveSingleUniqueForeignKey<int>
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("user_id")]
        public int UserId { get; set; }
        [Column("role_id")]
        public int RoleId { get; set; }
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

        [ForeignKey(nameof(RoleId))]
        public virtual Role Role { get; set; } = null!;
        [ForeignKey(nameof(StateId))]
        public virtual State State { get; set; } = null!;
        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; } = null!;

        public object GetUniqueForeignKey() => RoleId;

        public void SetUniqueForeignKey(int foreignKey) => RoleId = foreignKey;
    }
}
