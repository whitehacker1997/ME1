using Global.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnApp.DataLayer.Repository
{
    [Table("info_district")]
    public class District : 
        IHaveIdProp<int>,
        IHaveStateId
    {
        public District()
        {
            Translates = new HashSet<DistrictTranslate>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("order_code")]
        [StringLength(50)]
        public string? OrderCode { get; set; }
        [Column("code")]
        [StringLength(50)]
        public string? Code { get; set; }
        [Column("soato")]
        [StringLength(50)]
        public string? Soato { get; set; }
        [Column("roaming_code")]
        [StringLength(50)]
        public string? RoamingCode { get; set; }
        [Column("short_name")]
        [StringLength(250)]
        public string ShortName { get; set; } = null!;
        [Column("full_name")]
        [StringLength(250)]
        public string FullName { get; set; } = null!;
        [Column("region_id")]
        public int RegionId { get; set; }
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


        [ForeignKey(nameof(RegionId))]
        public virtual Region Region { get; set; } = null!;
        
       
        [ForeignKey(nameof(StateId))]
        public virtual State State { get; set; } = null!;


        [InverseProperty(nameof(DistrictTranslate.Owner))]
        public virtual ICollection<DistrictTranslate> Translates { get; set; }
    }
}
