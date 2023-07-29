using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OnApp.DataLayer.PgSql
{
    [Table("enum_state")]
    public partial class EnumState
    {
        public EnumState()
        {
            EnumDocumentTypes = new HashSet<EnumDocumentType>();
            EnumStateTranslates = new HashSet<EnumStateTranslate>();
            HlEmployees = new HashSet<HlEmployee>();
            HlPeople = new HashSet<HlPerson>();
            HlPositions = new HashSet<HlPosition>();
            HlRooms = new HashSet<HlRoom>();
            HlSubjects = new HashSet<HlSubject>();
            InfoCitizenships = new HashSet<InfoCitizenship>();
            InfoCountries = new HashSet<InfoCountry>();
            InfoDistricts = new HashSet<InfoDistrict>();
            InfoNationalities = new HashSet<InfoNationality>();
            InfoOrganizations = new HashSet<InfoOrganization>();
            InfoRegions = new HashSet<InfoRegion>();
            SysModules = new HashSet<SysModule>();
            SysRoles = new HashSet<SysRole>();
            SysUserRoles = new HashSet<SysUserRole>();
            SysUsers = new HashSet<SysUser>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("order_code")]
        [StringLength(5)]
        public string? OrderCode { get; set; }
        [Column("short_name")]
        [StringLength(250)]
        public string? ShortName { get; set; }
        [Column("full_name")]
        [StringLength(500)]
        public string? FullName { get; set; }
        [Column("created_at", TypeName = "timestamp without time zone")]
        public DateTime CreatedAt { get; set; }

        [InverseProperty("State")]
        public virtual ICollection<EnumDocumentType> EnumDocumentTypes { get; set; }
        [InverseProperty("Owner")]
        public virtual ICollection<EnumStateTranslate> EnumStateTranslates { get; set; }
        [InverseProperty("State")]
        public virtual ICollection<HlEmployee> HlEmployees { get; set; }
        [InverseProperty("State")]
        public virtual ICollection<HlPerson> HlPeople { get; set; }
        [InverseProperty("State")]
        public virtual ICollection<HlPosition> HlPositions { get; set; }
        [InverseProperty("State")]
        public virtual ICollection<HlRoom> HlRooms { get; set; }
        [InverseProperty("State")]
        public virtual ICollection<HlSubject> HlSubjects { get; set; }
        [InverseProperty("State")]
        public virtual ICollection<InfoCitizenship> InfoCitizenships { get; set; }
        [InverseProperty("State")]
        public virtual ICollection<InfoCountry> InfoCountries { get; set; }
        [InverseProperty("State")]
        public virtual ICollection<InfoDistrict> InfoDistricts { get; set; }
        [InverseProperty("State")]
        public virtual ICollection<InfoNationality> InfoNationalities { get; set; }
        [InverseProperty("State")]
        public virtual ICollection<InfoOrganization> InfoOrganizations { get; set; }
        [InverseProperty("State")]
        public virtual ICollection<InfoRegion> InfoRegions { get; set; }
        [InverseProperty("State")]
        public virtual ICollection<SysModule> SysModules { get; set; }
        [InverseProperty("State")]
        public virtual ICollection<SysRole> SysRoles { get; set; }
        [InverseProperty("State")]
        public virtual ICollection<SysUserRole> SysUserRoles { get; set; }
        [InverseProperty("State")]
        public virtual ICollection<SysUser> SysUsers { get; set; }
    }
}
