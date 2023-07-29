using Global.EF;
using Microsoft.EntityFrameworkCore;

namespace OnApp.DataLayer.Repository
{
    public class EfCoreContext :
        BaseDbContext
    {
        public EfCoreContext(DbContextOptions options)
            : base(options) 
        {
            /*  This code is for banning changeTracking in code .
             *  If you don't want synchronize changes with database this code is useful
             * ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
             */
        }

        #region ENUM
        public virtual DbSet<DocumentType> DocumentTypes { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }

        #endregion

        #region INFO
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<Organization> Organizations { get; set; }
        public virtual DbSet<Citizenship> Citizenships { get; set; }
        public virtual DbSet<Nationality> Nationalities { get; set; }

        #endregion

        #region HL
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        #endregion

        #region DOC

        #endregion

        #region SYS
        public virtual DbSet<Module> Modules { get; set; }
        public virtual DbSet<ModuleGroup> ModuleGroups { get; set; }
        public virtual DbSet<ModuleSubGroup> ModuleSubGroups { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<RoleModule> RoleModules { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserLog> UserLogs { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }

        #endregion

        #region Translates
        public virtual DbSet<StateTranslate> StateTranslates { get; set; }
        public virtual DbSet<CountryTranslate> CountryTranslates { get; set; }
        public virtual DbSet<RegionTranslate> RegionTranslates { get; set; }
        public virtual DbSet<DistrictTranslate> DistrictTranslates { get; set; }
        public virtual DbSet<OrganizationTranslate> OrganizationTranslates { get; set; }
        public virtual DbSet<StatusTranslate> StatusTranslates { get; set; }
        public virtual DbSet<GenderTranslate> GenderTranslates { get; set; }
        public virtual DbSet<CitizenshipTranslate> CitizenshipTranslates { get; set; }
        public virtual DbSet<NationalityTranslate> NationalityTranslates { get; set; }
        public virtual DbSet<ModuleGroupTranslate> ModuleGroupTranslates { get; set; }
        public virtual DbSet<ModuleTranslate> ModuleTranslates { get; set; }
        public virtual DbSet<ModuleSubGroupTranslate> ModuleSubGroupTranslates { get; set; }
        public virtual DbSet<RoleTranslate> RoleTranslates { get; set; }
        public virtual DbSet<PositionTranslate> PositionTranslates { get; set; }
        #endregion

        /*[DbFunction("function_name", schema: "public")]
        public IQueryable<Model> FuncName(int languageid,
            DateTime? p_start_date = null,
            DateTime? p_end_date = null) 
            => FromExpression(() => FuncName(
                languageid,
                p_start_date,
                p_end_date
                ));*/
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*modelBuilder.HasDbFunction(typeof(EfCoreContext).GetMethod(nameof(FuncName), new[] {
                typeof(int),
                typeof(DateTime?),
                typeof(DateTime?)
            }));*/
        }
    }
}
