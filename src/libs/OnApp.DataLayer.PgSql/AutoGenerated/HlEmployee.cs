using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OnApp.DataLayer.PgSql
{
    [Table("hl_employee")]
    [Index("StateId", "OrganizationId", Name = "ix_hl_employee__state_id__organization_id")]
    public partial class HlEmployee
    {
        public HlEmployee()
        {
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("parent_organization_id")]
        public int? ParentOrganizationId { get; set; }
        [Column("organization_id")]
        public int OrganizationId { get; set; }
        [Column("phone_number")]
        [StringLength(50)]
        public string? PhoneNumber { get; set; }
        [Column("position_id")]
        public int PositionId { get; set; }
        [Column("person_id")]
        public int PersonId { get; set; }
        [Column("user_id")]
        public int? UserId { get; set; }
        [Column("subject_id")]
        public int? SubjectId { get; set; }
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

        [ForeignKey("OrganizationId")]
        [InverseProperty("HlEmployeeOrganizations")]
        public virtual InfoOrganization Organization { get; set; } = null!;
        [ForeignKey("ParentOrganizationId")]
        [InverseProperty("HlEmployeeParentOrganizations")]
        public virtual InfoOrganization? ParentOrganization { get; set; }
        [ForeignKey("PersonId")]
        [InverseProperty("HlEmployees")]
        public virtual HlPerson Person { get; set; } = null!;
        [ForeignKey("PositionId")]
        [InverseProperty("HlEmployees")]
        public virtual HlPosition Position { get; set; } = null!;
        [ForeignKey("StateId")]
        [InverseProperty("HlEmployees")]
        public virtual EnumState State { get; set; } = null!;
        [ForeignKey("UserId")]
        [InverseProperty("HlEmployee")]
        public virtual SysUser? User { get; set; }
    }
}
