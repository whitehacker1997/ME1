using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OnApp.DataLayer.PgSql
{
    [Table("sys_module_sub_group")]
    [Index("Code", Name = "sys_module_sub_group_unique_index_code", IsUnique = true)]
    public partial class SysModuleSubGroup
    {
        public SysModuleSubGroup()
        {
            SysModuleSubGroupTranslates = new HashSet<SysModuleSubGroupTranslate>();
            SysModules = new HashSet<SysModule>();
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

        [ForeignKey("GroupId")]
        [InverseProperty("SysModuleSubGroups")]
        public virtual SysModuleGroup Group { get; set; } = null!;
        [InverseProperty("Owner")]
        public virtual ICollection<SysModuleSubGroupTranslate> SysModuleSubGroupTranslates { get; set; }
        [InverseProperty("SubGroup")]
        public virtual ICollection<SysModule> SysModules { get; set; }
    }
}
