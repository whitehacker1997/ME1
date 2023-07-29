using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Global.Models;
using Microsoft.EntityFrameworkCore;

namespace OnApp.DataLayer.Repository
{
    [Table("hl_employee")]
    [Index("StateId", "OrganizationId", Name = "ix_hl_employee__state_id__organization_id")]
    public class Employee : 
        IHaveIdProp<int>,
        IHaveStateId
    {
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


        [ForeignKey(nameof(OrganizationId))]
        public virtual Organization Organization { get; set; } = null!; 
        [ForeignKey(nameof(ParentOrganizationId))]
        public virtual Organization? ParentOrganization { get; set; }
        [ForeignKey(nameof(PersonId))]
        public virtual Person Person { get; set; } = null!;
        [ForeignKey(nameof(PositionId))]
        public virtual Position Position { get; set; } = null!;
        [ForeignKey(nameof(StateId))]
        public virtual State State { get; set; } = null!;
        [ForeignKey(nameof(UserId))]
        public virtual User? User { get; set; }
    }
}
