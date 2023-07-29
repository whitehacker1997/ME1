using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OnApp.DataLayer.PgSql
{
    [Table("sys_user")]
    [Index("OrganizationId", "StateId", Name = "sys_user_index_organization_id__state_id")]
    [Index("UserName", Name = "sys_user_index_user_name", IsUnique = true)]
    public partial class SysUser
    {
        public SysUser()
        {
            SysRoleModules = new HashSet<SysRoleModule>();
            SysUserRoles = new HashSet<SysUserRole>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("user_name")]
        [StringLength(250)]
        public string UserName { get; set; } = null!;
        [Column("password_hash")]
        [StringLength(250)]
        public string PasswordHash { get; set; } = null!;
        [Column("password_salt")]
        [StringLength(259)]
        public string PasswordSalt { get; set; } = null!;
        [Column("email")]
        [StringLength(259)]
        public string? Email { get; set; }
        [Column("phone_number")]
        [StringLength(50)]
        public string? PhoneNumber { get; set; }
        [Column("organization_id")]
        public int OrganizationId { get; set; }
        [Column("person_id")]
        public int PersonId { get; set; }
        [Column("language_id")]
        public int? LanguageId { get; set; }
        [Column("last_access_time", TypeName = "timestamp without time zone")]
        public DateTime? LastAccessTime { get; set; }
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

        [ForeignKey("LanguageId")]
        [InverseProperty("SysUsers")]
        public virtual EnumLanguage? Language { get; set; }
        [ForeignKey("OrganizationId")]
        [InverseProperty("SysUsers")]
        public virtual InfoOrganization Organization { get; set; } = null!;
        [ForeignKey("PersonId")]
        [InverseProperty("SysUsers")]
        public virtual HlPerson Person { get; set; } = null!;
        [ForeignKey("StateId")]
        [InverseProperty("SysUsers")]
        public virtual EnumState State { get; set; } = null!;
        [InverseProperty("User")]
        public virtual HlEmployee? HlEmployee { get; set; }
        [InverseProperty("CreatedByNavigation")]
        public virtual ICollection<SysRoleModule> SysRoleModules { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<SysUserRole> SysUserRoles { get; set; }
    }
}
