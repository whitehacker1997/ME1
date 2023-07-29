using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnApp.DataLayer.Repository
{
    [Table("sys_module_group")]
    public partial class ModuleGroup
    {
        public ModuleGroup()
        {
            Translates = new HashSet<ModuleGroupTranslate>();
            SubGroups = new HashSet<ModuleSubGroup>();
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
        [StringLength(300)]
        public string FullName { get; set; } = null!;
        [Column("created_at", TypeName = "timestamp without time zone")]
        public DateTime? CreatedAt { get; set; }

        [InverseProperty(nameof(ModuleGroupTranslate.Owner))]
        public virtual ICollection<ModuleGroupTranslate> Translates { get; set; }
        [InverseProperty(nameof(ModuleSubGroup.Group))]
        public virtual ICollection<ModuleSubGroup> SubGroups { get; set; }
    }
}
