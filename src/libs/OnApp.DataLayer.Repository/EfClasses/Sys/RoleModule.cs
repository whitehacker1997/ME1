using Global.EF;
using Global.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnApp.DataLayer.Repository
{
    [Table("sys_role_module")]
    public class RoleModule : 
        IHaveSingleUniqueForeignKey<int>,
        IHaveIdProp<int>
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("role_id")]
        public int RoleId { get; set; }
        [Column("module_id")]
        public int ModuleId { get; set; }
        [Column("created_by")]
        public int CreatedBy { get; set; }
        [Column("modified_by")]
        public int? ModifiedBy { get; set; }
        [Column("created_at", TypeName = "timestamp without time zone")]
        public DateTime CreatedAt { get; set; }


        [ForeignKey(nameof(CreatedBy))]
        public virtual User CreatedUser { get; set; } = null!;
        [ForeignKey(nameof(ModuleId))]
        public virtual Module Module { get; set; } = null!;
        [ForeignKey(nameof(RoleId))]
        public virtual Role Role { get; set; } = null!;

        public object GetUniqueForeignKey() 
            => ModuleId;
        public void SetUniqueForeignKey(int foreignKey)
            => ModuleId = foreignKey;
    }
}
