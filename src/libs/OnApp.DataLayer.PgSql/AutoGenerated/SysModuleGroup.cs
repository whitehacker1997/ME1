using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OnApp.DataLayer.PgSql
{
    [Table("sys_module_group")]
    public partial class SysModuleGroup
    {
        public SysModuleGroup()
        {
            SysModuleGroupTranslates = new HashSet<SysModuleGroupTranslate>();
            SysModuleSubGroups = new HashSet<SysModuleSubGroup>();
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

        [InverseProperty("Owner")]
        public virtual ICollection<SysModuleGroupTranslate> SysModuleGroupTranslates { get; set; }
        [InverseProperty("Group")]
        public virtual ICollection<SysModuleSubGroup> SysModuleSubGroups { get; set; }
    }
}
