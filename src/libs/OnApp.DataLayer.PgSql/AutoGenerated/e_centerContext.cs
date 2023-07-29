using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OnApp.DataLayer.PgSql
{
    public partial class e_centerContext : DbContext
    {
        public e_centerContext()
        {
        }

        public e_centerContext(DbContextOptions<e_centerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EnumDocumentType> EnumDocumentTypes { get; set; } = null!;
        public virtual DbSet<EnumDocumentTypeTranslate> EnumDocumentTypeTranslates { get; set; } = null!;
        public virtual DbSet<EnumGender> EnumGenders { get; set; } = null!;
        public virtual DbSet<EnumGenderTranslate> EnumGenderTranslates { get; set; } = null!;
        public virtual DbSet<EnumLanguage> EnumLanguages { get; set; } = null!;
        public virtual DbSet<EnumState> EnumStates { get; set; } = null!;
        public virtual DbSet<EnumStateTranslate> EnumStateTranslates { get; set; } = null!;
        public virtual DbSet<EnumStatus> EnumStatuses { get; set; } = null!;
        public virtual DbSet<EnumStatusTranslate> EnumStatusTranslates { get; set; } = null!;
        public virtual DbSet<HlEmployee> HlEmployees { get; set; } = null!;
        public virtual DbSet<HlPerson> HlPeople { get; set; } = null!;
        public virtual DbSet<HlPosition> HlPositions { get; set; } = null!;
        public virtual DbSet<HlPositionTranslate> HlPositionTranslates { get; set; } = null!;
        public virtual DbSet<HlRoom> HlRooms { get; set; } = null!;
        public virtual DbSet<HlSubject> HlSubjects { get; set; } = null!;
        public virtual DbSet<HlSubjectTranslate> HlSubjectTranslates { get; set; } = null!;
        public virtual DbSet<InfoCitizenship> InfoCitizenships { get; set; } = null!;
        public virtual DbSet<InfoCitizenshipTranslate> InfoCitizenshipTranslates { get; set; } = null!;
        public virtual DbSet<InfoCountry> InfoCountries { get; set; } = null!;
        public virtual DbSet<InfoCountryTranslate> InfoCountryTranslates { get; set; } = null!;
        public virtual DbSet<InfoDistrict> InfoDistricts { get; set; } = null!;
        public virtual DbSet<InfoDistrictTranslate> InfoDistrictTranslates { get; set; } = null!;
        public virtual DbSet<InfoNationality> InfoNationalities { get; set; } = null!;
        public virtual DbSet<InfoNationalityTranslate> InfoNationalityTranslates { get; set; } = null!;
        public virtual DbSet<InfoOrganization> InfoOrganizations { get; set; } = null!;
        public virtual DbSet<InfoOrganizationTranslate> InfoOrganizationTranslates { get; set; } = null!;
        public virtual DbSet<InfoRegion> InfoRegions { get; set; } = null!;
        public virtual DbSet<InfoRegionTranslate> InfoRegionTranslates { get; set; } = null!;
        public virtual DbSet<SysModule> SysModules { get; set; } = null!;
        public virtual DbSet<SysModuleGroup> SysModuleGroups { get; set; } = null!;
        public virtual DbSet<SysModuleGroupTranslate> SysModuleGroupTranslates { get; set; } = null!;
        public virtual DbSet<SysModuleSubGroup> SysModuleSubGroups { get; set; } = null!;
        public virtual DbSet<SysModuleSubGroupTranslate> SysModuleSubGroupTranslates { get; set; } = null!;
        public virtual DbSet<SysModuleTranslate> SysModuleTranslates { get; set; } = null!;
        public virtual DbSet<SysRole> SysRoles { get; set; } = null!;
        public virtual DbSet<SysRoleModule> SysRoleModules { get; set; } = null!;
        public virtual DbSet<SysRoleTranslate> SysRoleTranslates { get; set; } = null!;
        public virtual DbSet<SysUser> SysUsers { get; set; } = null!;
        public virtual DbSet<SysUserLog> SysUserLogs { get; set; } = null!;
        public virtual DbSet<SysUserRole> SysUserRoles { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=my-database-instance.c3cm2cki4uqk.ap-southeast-1.rds.amazonaws.com;Username=postgres;Password=postgres;Database=e_center;Pooling=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EnumDocumentType>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.EnumDocumentTypes)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_state_id");
            });

            modelBuilder.Entity<EnumDocumentTypeTranslate>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.EnumDocumentTypeTranslates)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_language_id");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.EnumDocumentTypeTranslates)
                    .HasForeignKey(d => d.OwnerId)
                    .HasConstraintName("fk_owner_id");
            });

            modelBuilder.Entity<EnumGender>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            });

            modelBuilder.Entity<EnumGenderTranslate>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.EnumGenderTranslates)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_language_id");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.EnumGenderTranslates)
                    .HasForeignKey(d => d.OwnerId)
                    .HasConstraintName("fk_owner_id");
            });

            modelBuilder.Entity<EnumLanguage>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            });

            modelBuilder.Entity<EnumState>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            });

            modelBuilder.Entity<EnumStateTranslate>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.EnumStateTranslates)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_language_id");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.EnumStateTranslates)
                    .HasForeignKey(d => d.OwnerId)
                    .HasConstraintName("fk_owner_id");
            });

            modelBuilder.Entity<EnumStatus>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            });

            modelBuilder.Entity<EnumStatusTranslate>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.EnumStatusTranslates)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_language_id");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.EnumStatusTranslates)
                    .HasForeignKey(d => d.OwnerId)
                    .HasConstraintName("fk_owner_id");
            });

            modelBuilder.Entity<HlEmployee>(entity =>
            {
                entity.HasIndex(e => e.UserId, "uix_hl_employee__user_id")
                    .IsUnique()
                    .HasFilter("(user_id IS NOT NULL)");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.HlEmployeeOrganizations)
                    .HasForeignKey(d => d.OrganizationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_organization_id");

                entity.HasOne(d => d.ParentOrganization)
                    .WithMany(p => p.HlEmployeeParentOrganizations)
                    .HasForeignKey(d => d.ParentOrganizationId)
                    .HasConstraintName("fk_parent_organization_id");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.HlEmployees)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_person_id");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.HlEmployees)
                    .HasForeignKey(d => d.PositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_position_id");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.HlEmployees)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_state_id");

                entity.HasOne(d => d.User)
                    .WithOne(p => p.HlEmployee)
                    .HasForeignKey<HlEmployee>(d => d.UserId)
                    .HasConstraintName("fk_user_id");
            });

            modelBuilder.Entity<HlPerson>(entity =>
            {
                entity.HasIndex(e => e.Inn, "hl_person_unique_index_inn")
                    .IsUnique()
                    .HasFilter("(inn IS NOT NULL)");

                entity.HasIndex(e => e.Pinfl, "hl_person_unique_index_pinfl")
                    .IsUnique()
                    .HasFilter("(pinfl IS NOT NULL)");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");

                entity.HasOne(d => d.BirthCountry)
                    .WithMany(p => p.HlPeople)
                    .HasForeignKey(d => d.BirthCountryId)
                    .HasConstraintName("fk_birth_country_id");

                entity.HasOne(d => d.BirthDistrict)
                    .WithMany(p => p.HlPersonBirthDistricts)
                    .HasForeignKey(d => d.BirthDistrictId)
                    .HasConstraintName("fk_birth_district_id");

                entity.HasOne(d => d.BirthRegion)
                    .WithMany(p => p.HlPersonBirthRegions)
                    .HasForeignKey(d => d.BirthRegionId)
                    .HasConstraintName("fk_birth_region_id");

                entity.HasOne(d => d.Citizenship)
                    .WithMany(p => p.HlPeople)
                    .HasForeignKey(d => d.CitizenshipId)
                    .HasConstraintName("fk_citizenship_id");

                entity.HasOne(d => d.DocumentType)
                    .WithMany(p => p.HlPeople)
                    .HasForeignKey(d => d.DocumentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_document_type_id");

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.HlPeople)
                    .HasForeignKey(d => d.GenderId)
                    .HasConstraintName("fk_gender_id");

                entity.HasOne(d => d.LivingDistrict)
                    .WithMany(p => p.HlPersonLivingDistricts)
                    .HasForeignKey(d => d.LivingDistrictId)
                    .HasConstraintName("fk_living_district_id");

                entity.HasOne(d => d.LivingRegion)
                    .WithMany(p => p.HlPersonLivingRegions)
                    .HasForeignKey(d => d.LivingRegionId)
                    .HasConstraintName("fk_living_region_id");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.HlPeople)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_state_id");
            });

            modelBuilder.Entity<HlPosition>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.HlPositions)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_state_id");
            });

            modelBuilder.Entity<HlPositionTranslate>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.HlPositionTranslates)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_language_id");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.HlPositionTranslates)
                    .HasForeignKey(d => d.OwnerId)
                    .HasConstraintName("fk_owner_id");
            });

            modelBuilder.Entity<HlRoom>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.HlRooms)
                    .HasForeignKey(d => d.OrganizationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_organization_id");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.HlRooms)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_state_id");
            });


            modelBuilder.Entity<HlSubject>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.HlSubjects)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_state_id");
            });

            modelBuilder.Entity<HlSubjectTranslate>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.HlSubjectTranslates)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_language_id");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.HlSubjectTranslates)
                    .HasForeignKey(d => d.OwnerId)
                    .HasConstraintName("fk_owner_id");
            });

            modelBuilder.Entity<InfoCitizenship>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.InfoCitizenships)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_state_id");
            });

            modelBuilder.Entity<InfoCitizenshipTranslate>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.InfoCitizenshipTranslates)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_language_id");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.InfoCitizenshipTranslates)
                    .HasForeignKey(d => d.OwnerId)
                    .HasConstraintName("fk_owner_id");
            });

            modelBuilder.Entity<InfoCountry>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.InfoCountries)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_state_id");
            });

            modelBuilder.Entity<InfoCountryTranslate>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.InfoCountryTranslates)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_language_id");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.InfoCountryTranslates)
                    .HasForeignKey(d => d.OwnerId)
                    .HasConstraintName("fk_owner_id");
            });

            modelBuilder.Entity<InfoDistrict>(entity =>
            {
                entity.HasIndex(e => e.Code, "info_district_unique_index_code")
                    .IsUnique()
                    .HasFilter("(code IS NOT NULL)");

                entity.HasIndex(e => e.RoamingCode, "info_district_unique_index_roaming_code")
                    .IsUnique()
                    .HasFilter("(roaming_code IS NOT NULL)");

                entity.HasIndex(e => e.Soato, "info_district_unique_index_soato")
                    .IsUnique()
                    .HasFilter("(soato IS NOT NULL)");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.InfoDistricts)
                    .HasForeignKey(d => d.RegionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_region_id");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.InfoDistricts)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_state_id");
            });

            modelBuilder.Entity<InfoDistrictTranslate>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.InfoDistrictTranslates)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_language_id");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.InfoDistrictTranslates)
                    .HasForeignKey(d => d.OwnerId)
                    .HasConstraintName("fk_owner_id");
            });

            modelBuilder.Entity<InfoNationality>(entity =>
            {
                entity.HasIndex(e => e.WbCode, "info_citizenship_unique_index_wb_code")
                    .IsUnique()
                    .HasFilter("(wb_code IS NOT NULL)");

                entity.HasIndex(e => e.WbCode, "info_nationality_unique_index_wb_code")
                    .IsUnique()
                    .HasFilter("(wb_code IS NOT NULL)");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.InfoNationalities)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_state_id");
            });

            modelBuilder.Entity<InfoNationalityTranslate>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.InfoNationalityTranslates)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_language_id");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.InfoNationalityTranslates)
                    .HasForeignKey(d => d.OwnerId)
                    .HasConstraintName("fk_owner_id");
            });

            modelBuilder.Entity<InfoOrganization>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.InfoOrganizations)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_country_id");

                entity.HasOne(d => d.District)
                    .WithMany(p => p.InfoOrganizations)
                    .HasForeignKey(d => d.DistrictId)
                    .HasConstraintName("fk_district_id");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("fk_parent_id");

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.InfoOrganizations)
                    .HasForeignKey(d => d.RegionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_region_id");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.InfoOrganizations)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_state_id");
            });

            modelBuilder.Entity<InfoOrganizationTranslate>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.InfoOrganizationTranslates)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_language_id");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.InfoOrganizationTranslates)
                    .HasForeignKey(d => d.OwnerId)
                    .HasConstraintName("fk_owner_id");
            });

            modelBuilder.Entity<InfoRegion>(entity =>
            {
                entity.HasIndex(e => e.RoamingCode, "info_region_unique_index_roaming_code")
                    .IsUnique()
                    .HasFilter("(roaming_code IS NOT NULL)");

                entity.HasIndex(e => e.Soato, "info_region_unique_index_soato")
                    .IsUnique()
                    .HasFilter("(soato IS NOT NULL)");

                entity.HasIndex(e => e.Code, "info_region_uniques_index_code")
                    .IsUnique()
                    .HasFilter("(code IS NOT NULL)");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.InfoRegions)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_country_id");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.InfoRegions)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_state_id");
            });

            modelBuilder.Entity<InfoRegionTranslate>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.InfoRegionTranslates)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_language_id");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.InfoRegionTranslates)
                    .HasForeignKey(d => d.OwnerId)
                    .HasConstraintName("fk_owner_id");
            });

            modelBuilder.Entity<SysModule>(entity =>
            {
                entity.HasOne(d => d.State)
                    .WithMany(p => p.SysModules)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_state_id");

                entity.HasOne(d => d.SubGroup)
                    .WithMany(p => p.SysModules)
                    .HasForeignKey(d => d.SubGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_sub_group_id");
            });

            modelBuilder.Entity<SysModuleGroup>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            });

            modelBuilder.Entity<SysModuleGroupTranslate>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.SysModuleGroupTranslates)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_language_id");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.SysModuleGroupTranslates)
                    .HasForeignKey(d => d.OwnerId)
                    .HasConstraintName("fk_owner_id");
            });

            modelBuilder.Entity<SysModuleSubGroup>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.SysModuleSubGroups)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_group_id");
            });

            modelBuilder.Entity<SysModuleSubGroupTranslate>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.SysModuleSubGroupTranslates)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_language_id");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.SysModuleSubGroupTranslates)
                    .HasForeignKey(d => d.OwnerId)
                    .HasConstraintName("fk_owner_id");
            });

            modelBuilder.Entity<SysModuleTranslate>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.SysModuleTranslates)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_language_id");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.SysModuleTranslates)
                    .HasForeignKey(d => d.OwnerId)
                    .HasConstraintName("fk_owner_id");
            });

            modelBuilder.Entity<SysRole>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.SysRoles)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_state_id");
            });

            modelBuilder.Entity<SysRoleModule>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.SysRoleModules)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_created_by");

                entity.HasOne(d => d.Module)
                    .WithMany(p => p.SysRoleModules)
                    .HasForeignKey(d => d.ModuleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_module_id");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.SysRoleModules)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("fk_role_id");
            });

            modelBuilder.Entity<SysRoleTranslate>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.SysRoleTranslates)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_language_id");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.SysRoleTranslates)
                    .HasForeignKey(d => d.OwnerId)
                    .HasConstraintName("fk_owner_id");
            });

            modelBuilder.Entity<SysUser>(entity =>
            {
                entity.HasIndex(e => e.Email, "sys_user_index_email")
                    .IsUnique()
                    .HasFilter("(email IS NOT NULL)");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.SysUsers)
                    .HasForeignKey(d => d.LanguageId)
                    .HasConstraintName("fk_language_id");

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.SysUsers)
                    .HasForeignKey(d => d.OrganizationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_organization_id");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.SysUsers)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_person_id");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.SysUsers)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_state_id");
            });

            modelBuilder.Entity<SysUserLog>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            });

            modelBuilder.Entity<SysUserRole>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.SysUserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_role_id");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.SysUserRoles)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_state_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.SysUserRoles)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_user_id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
