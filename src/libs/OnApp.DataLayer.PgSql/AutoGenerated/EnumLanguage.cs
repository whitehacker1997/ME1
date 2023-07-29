using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OnApp.DataLayer.PgSql
{
    [Table("enum_language")]
    public partial class EnumLanguage
    {
        public EnumLanguage()
        {
            EnumDocumentTypeTranslates = new HashSet<EnumDocumentTypeTranslate>();
            EnumGenderTranslates = new HashSet<EnumGenderTranslate>();
            EnumStateTranslates = new HashSet<EnumStateTranslate>();
            EnumStatusTranslates = new HashSet<EnumStatusTranslate>();
            HlPositionTranslates = new HashSet<HlPositionTranslate>();
            HlSubjectTranslates = new HashSet<HlSubjectTranslate>();
            InfoCitizenshipTranslates = new HashSet<InfoCitizenshipTranslate>();
            InfoCountryTranslates = new HashSet<InfoCountryTranslate>();
            InfoDistrictTranslates = new HashSet<InfoDistrictTranslate>();
            InfoNationalityTranslates = new HashSet<InfoNationalityTranslate>();
            InfoOrganizationTranslates = new HashSet<InfoOrganizationTranslate>();
            InfoRegionTranslates = new HashSet<InfoRegionTranslate>();
            SysModuleGroupTranslates = new HashSet<SysModuleGroupTranslate>();
            SysModuleSubGroupTranslates = new HashSet<SysModuleSubGroupTranslate>();
            SysModuleTranslates = new HashSet<SysModuleTranslate>();
            SysRoleTranslates = new HashSet<SysRoleTranslate>();
            SysUsers = new HashSet<SysUser>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("code")]
        [StringLength(10)]
        public string Code { get; set; } = null!;
        [Column("short_name")]
        [StringLength(50)]
        public string ShortName { get; set; } = null!;
        [Column("full_name")]
        [StringLength(100)]
        public string FullName { get; set; } = null!;
        [Column("created_at", TypeName = "timestamp without time zone")]
        public DateTime CreatedAt { get; set; }

        [InverseProperty("Language")]
        public virtual ICollection<EnumDocumentTypeTranslate> EnumDocumentTypeTranslates { get; set; }
        [InverseProperty("Language")]
        public virtual ICollection<EnumGenderTranslate> EnumGenderTranslates { get; set; }
        [InverseProperty("Language")]
        public virtual ICollection<EnumStateTranslate> EnumStateTranslates { get; set; }
        [InverseProperty("Language")]
        public virtual ICollection<EnumStatusTranslate> EnumStatusTranslates { get; set; }
        [InverseProperty("Language")]
        public virtual ICollection<HlPositionTranslate> HlPositionTranslates { get; set; }
        [InverseProperty("Language")]
        public virtual ICollection<HlSubjectTranslate> HlSubjectTranslates { get; set; }
        [InverseProperty("Language")]
        public virtual ICollection<InfoCitizenshipTranslate> InfoCitizenshipTranslates { get; set; }
        [InverseProperty("Language")]
        public virtual ICollection<InfoCountryTranslate> InfoCountryTranslates { get; set; }
        [InverseProperty("Language")]
        public virtual ICollection<InfoDistrictTranslate> InfoDistrictTranslates { get; set; }
        [InverseProperty("Language")]
        public virtual ICollection<InfoNationalityTranslate> InfoNationalityTranslates { get; set; }
        [InverseProperty("Language")]
        public virtual ICollection<InfoOrganizationTranslate> InfoOrganizationTranslates { get; set; }
        [InverseProperty("Language")]
        public virtual ICollection<InfoRegionTranslate> InfoRegionTranslates { get; set; }
        [InverseProperty("Language")]
        public virtual ICollection<SysModuleGroupTranslate> SysModuleGroupTranslates { get; set; }
        [InverseProperty("Language")]
        public virtual ICollection<SysModuleSubGroupTranslate> SysModuleSubGroupTranslates { get; set; }
        [InverseProperty("Language")]
        public virtual ICollection<SysModuleTranslate> SysModuleTranslates { get; set; }
        [InverseProperty("Language")]
        public virtual ICollection<SysRoleTranslate> SysRoleTranslates { get; set; }
        [InverseProperty("Language")]
        public virtual ICollection<SysUser> SysUsers { get; set; }
    }
}
