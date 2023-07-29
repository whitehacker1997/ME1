using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Global.EF;
using Global.Models;
using Microsoft.EntityFrameworkCore;

namespace OnApp.DataLayer.Repository
{
    [Table("sys_module")]
    [Index("Code",
            Name = "uk_sys_module_code",
            IsUnique = true)]
    public class Module :
        IModule<ModuleTranslate, ModuleSubGroup, ModuleSubGroupTranslate>,
        IHaveStateId,
        IHaveIdProp<int>
    {
        public Module()
        {
            Translates = new HashSet<ModuleTranslate>();
            Modules = new HashSet<RoleModule>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("order_code")]
        [StringLength(50)]
        public string? OrderCode { get; set; }
        [Column("code")]
        [StringLength(100)]
        public string Code { get; set; } = null!;
        [Column("short_name")]
        [StringLength(250)]
        public string ShortName { get; set; } = null!;
        [Column("full_name")]
        [StringLength(300)]
        public string FullName { get; set; } = null!;
        [Column("sub_group_id")]
        public int SubGroupId { get; set; }
        [Column("state_id")]
        public int StateId { get; set; }



        [ForeignKey(nameof(StateId))]
        public virtual State State { get; set; } = null!;
        [ForeignKey(nameof(SubGroupId))]
        public virtual ModuleSubGroup SubGroup { get; set; } = null!;
        [InverseProperty(nameof(ModuleTranslate.Owner))]
        public virtual ICollection<ModuleTranslate> Translates { get; set; }
        [InverseProperty(nameof(RoleModule.Module))]
        public virtual ICollection<RoleModule> Modules { get; set; }
    }
}
