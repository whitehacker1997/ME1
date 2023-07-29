using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Global.EF;
using Global.Models;
using Microsoft.EntityFrameworkCore;

namespace OnApp.DataLayer.Repository
{
    [Table("sys_module_sub_group")]
    [Index(
        "Code",
        Name = "sys_module_sub_group_unique_index_code",
        IsUnique = true)]
    public class ModuleSubGroup :
        IModuleSubGroup<ModuleSubGroupTranslate>, IHaveIdProp<int>
    {
        public ModuleSubGroup()
        {
            Translates = new HashSet<ModuleSubGroupTranslate>();
            Modules = new HashSet<Module>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("code")]
        [StringLength(100)]
        public string Code { get; set; } = null!;
        [Column("short_name")]
        [StringLength(250)]
        public string ShortName { get; set; } = null!;
        [Column("full_name")]
        [StringLength(300)]
        public string FullName { get; set; } = null!;
        [Column("group_id")]
        public int GroupId { get; set; }
        [Column("created_at", TypeName = "timestamp without time zone")]
        public DateTime CreatedAt { get; set; }
        [Column("created_by")]
        public int? CreatedBy { get; set; }
        [Column("modified_at", TypeName = "timestamp without time zone")]
        public DateTime? ModifiedAt { get; set; }
        [Column("modified_by")]
        public int? ModifiedBy { get; set; }


        [ForeignKey(nameof(GroupId))]
        public virtual ModuleGroup Group { get; set; } = null!;
        [InverseProperty(nameof(ModuleSubGroupTranslate.Owner))]
        public virtual ICollection<ModuleSubGroupTranslate> Translates { get; set; }
        [InverseProperty(nameof(Module.SubGroup))]
        public virtual ICollection<Module> Modules { get; set; }
    }
}
