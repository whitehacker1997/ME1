using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OnApp.DataLayer.PgSql
{
    [Table("sys_module")]
    [Index("Code", Name = "uk_sys_module_code", IsUnique = true)]
    public partial class SysModule
    {
        public SysModule()
        {
            SysModuleTranslates = new HashSet<SysModuleTranslate>();
            SysRoleModules = new HashSet<SysRoleModule>();
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

        [ForeignKey("StateId")]
        [InverseProperty("SysModules")]
        public virtual EnumState State { get; set; } = null!;
        [ForeignKey("SubGroupId")]
        [InverseProperty("SysModules")]
        public virtual SysModuleSubGroup SubGroup { get; set; } = null!;
        [InverseProperty("Owner")]
        public virtual ICollection<SysModuleTranslate> SysModuleTranslates { get; set; }
        [InverseProperty("Module")]
        public virtual ICollection<SysRoleModule> SysRoleModules { get; set; }
    }
}
