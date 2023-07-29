using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OnApp.DataLayer.PgSql
{
    [Table("sys_role_module")]
    public partial class SysRoleModule
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

        [ForeignKey("CreatedBy")]
        [InverseProperty("SysRoleModules")]
        public virtual SysUser CreatedByNavigation { get; set; } = null!;
        [ForeignKey("ModuleId")]
        [InverseProperty("SysRoleModules")]
        public virtual SysModule Module { get; set; } = null!;
        [ForeignKey("RoleId")]
        [InverseProperty("SysRoleModules")]
        public virtual SysRole Role { get; set; } = null!;
    }
}
