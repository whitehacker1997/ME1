using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OnApp.DataLayer.PgSql
{
    [Table("sys_user_role")]
    public partial class SysUserRole
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

        [ForeignKey("RoleId")]
        [InverseProperty("SysUserRoles")]
        public virtual SysRole Role { get; set; } = null!;
        [ForeignKey("StateId")]
        [InverseProperty("SysUserRoles")]
        public virtual EnumState State { get; set; } = null!;
        [ForeignKey("UserId")]
        [InverseProperty("SysUserRoles")]
        public virtual SysUser User { get; set; } = null!;
    }
}
