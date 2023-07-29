using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OnApp.DataLayer.PgSql
{
    [Table("hl_room")]
    public partial class HlRoom
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("order_code")]
        [StringLength(10)]
        public string? OrderCode { get; set; }
        [Column("floor")]
        public int? Floor { get; set; }
        [Column("room_number")]
        [StringLength(250)]
        public string RoomNumber { get; set; } = null!;
        [Column("organization_id")]
        public int OrganizationId { get; set; }
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
        [InverseProperty("HlRooms")]
        public virtual InfoOrganization Organization { get; set; } = null!;
        [ForeignKey("StateId")]
        [InverseProperty("HlRooms")]
        public virtual EnumState State { get; set; } = null!;
    }
}
