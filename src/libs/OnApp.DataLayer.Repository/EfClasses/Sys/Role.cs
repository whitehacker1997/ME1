using Global.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnApp.DataLayer.Repository
{
    [Table("sys_role")]
    public class Role : 
        IHaveIdProp<int>,
        IHaveStateId
    {
        public Role()
        {
            RoleModules = new HashSet<RoleModule>();
            Translates = new HashSet<RoleTranslate>();
            UserRoles = new HashSet<UserRole>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("order_code")]
        [StringLength(20)]
        public string? OrderCode { get; set; }
        [Column("short_name")]
        [StringLength(250)]
        public string ShortName { get; set; } = null!;
        [Column("full_name")]
        [StringLength(500)]
        public string FullName { get; set; } = null!;
        [Column("is_admin")]
        public bool IsAdmin { get; set; }
        [Column("is_default")]
        public bool IsDefault { get; set; }
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
        public virtual State State { get; set; }
        [InverseProperty(nameof(RoleModule.Role))]
        public virtual ICollection<RoleModule> RoleModules { get; set; }
        [InverseProperty(nameof(RoleTranslate.Owner))]
        public virtual ICollection<RoleTranslate> Translates { get; set; }
        [InverseProperty(nameof(UserRole.Role))]
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
