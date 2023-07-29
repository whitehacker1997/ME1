using GenericServices;

namespace OnApp.DataLayer.Repository
{
    public class UnitOfWork :
        BaseUnitOfWork,
        IUnitOfWork
    {
        public UnitOfWork(
            ICrudServices crudServices,
            IServiceProvider serviceProvider)
            : base(crudServices, serviceProvider)
        {
        }

        #region INFO
        public ICountryRepository CountryRepository
        { get => GetRepository<ICountryRepository>(); }

        public IRegionRepository RegionRepository
        { get => GetRepository<IRegionRepository>(); }

        public IDistrictRepository DistrictRepository
        { get => GetRepository<IDistrictRepository>(); }

        public IOrganizationRepository OrganizationRepository
        { get => GetRepository<IOrganizationRepository>(); }

        public INationalityRepository NationalityRepository
        { get => GetRepository<INationalityRepository>(); }

        public ICitizenshipRepository CitizenshipRepository
        { get => GetRepository<ICitizenshipRepository>(); }

        #endregion

        #region Hl
        public IPositionRepository PositionRepository
        { get => GetRepository<IPositionRepository>(); }
        public IPersonRepository PersonRepository
        { get => GetRepository<IPersonRepository>(); }
        public IEmployeeRepository EmployeeRepository
        { get => GetRepository<IEmployeeRepository>(); }
        public IRoomRepository RoomRepository
        { get => GetRepository<IRoomRepository>(); }
        #endregion

        #region DOC

        #endregion

        #region SYS
        public IAccountRepository AccountRepository
        { get => GetRepository<IAccountRepository>(); }
        public IRoleRepository RoleRepository
        { get => GetRepository<IRoleRepository>(); }
        public IUserRepository UserRepository
        { get => GetRepository<IUserRepository>(); }
        #endregion
    }
}
