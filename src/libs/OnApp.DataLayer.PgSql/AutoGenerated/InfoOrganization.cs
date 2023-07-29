using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OnApp.DataLayer.PgSql
{
    [Table("info_organization")]
    [Index("Inn", Name = "info_organization_unique_index_inn", IsUnique = true)]
    public partial class InfoOrganization
    {
        public InfoOrganization()
        {
            HlEmployeeOrganizations = new HashSet<HlEmployee>();
            HlEmployeeParentOrganizations = new HashSet<HlEmployee>();
            HlRooms = new HashSet<HlRoom>();
            InfoOrganizationTranslates = new HashSet<InfoOrganizationTranslate>();
            InverseParent = new HashSet<InfoOrganization>();
            SysUsers = new HashSet<SysUser>();
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
        [Column("inn")]
        [StringLength(9)]
        public string? Inn { get; set; }
        [Column("parent_id")]
        public int? ParentId { get; set; }
        [Column("country_id")]
        public int CountryId { get; set; }
        [Column("region_id")]
        public int RegionId { get; set; }
        [Column("district_id")]
        public int? DistrictId { get; set; }
        [Column("address")]
        [StringLength(500)]
        public string? Address { get; set; }
        [Column("phone_number")]
        [StringLength(250)]
        public string? PhoneNumber { get; set; }
        [Column("oked_id")]
        public int? OkedId { get; set; }
        [Column("director")]
        [StringLength(250)]
        public string? Director { get; set; }
        [Column("vat_code")]
        [StringLength(12)]
        public string? VatCode { get; set; }
        [Column("zip_code")]
        [StringLength(50)]
        public string? ZipCode { get; set; }
        [Column("latitude")]
        [StringLength(50)]
        public string? Latitude { get; set; }
        [Column("longitude")]
        [StringLength(50)]
        public string? Longitude { get; set; }
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

        [ForeignKey("CountryId")]
        [InverseProperty("InfoOrganizations")]
        public virtual InfoCountry Country { get; set; } = null!;
        [ForeignKey("DistrictId")]
        [InverseProperty("InfoOrganizations")]
        public virtual InfoDistrict? District { get; set; }
        [ForeignKey("ParentId")]
        [InverseProperty("InverseParent")]
        public virtual InfoOrganization? Parent { get; set; }
        [ForeignKey("RegionId")]
        [InverseProperty("InfoOrganizations")]
        public virtual InfoRegion Region { get; set; } = null!;
        [ForeignKey("StateId")]
        [InverseProperty("InfoOrganizations")]
        public virtual EnumState State { get; set; } = null!;
        [InverseProperty("Organization")]
        public virtual ICollection<HlEmployee> HlEmployeeOrganizations { get; set; }
        [InverseProperty("ParentOrganization")]
        public virtual ICollection<HlEmployee> HlEmployeeParentOrganizations { get; set; }
        [InverseProperty("Organization")]
        public virtual ICollection<HlRoom> HlRooms { get; set; }
        [InverseProperty("Owner")]
        public virtual ICollection<InfoOrganizationTranslate> InfoOrganizationTranslates { get; set; }
        [InverseProperty("Parent")]
        public virtual ICollection<InfoOrganization> InverseParent { get; set; }
        [InverseProperty("Organization")]
        public virtual ICollection<SysUser> SysUsers { get; set; }
    }
}
