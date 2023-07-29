namespace OnApp.DataLayer.Repository
{
    public interface IUnitOfWork : 
        IBaseUnitOfWork
    {
        #region INFO
        ICountryRepository CountryRepository { get; }
        IRegionRepository RegionRepository { get; }
        IDistrictRepository DistrictRepository { get; }
        IOrganizationRepository OrganizationRepository { get; }
        INationalityRepository NationalityRepository { get; }
        ICitizenshipRepository CitizenshipRepository { get; }

        #endregion

        #region Hl
        IPositionRepository PositionRepository { get; }
        IPersonRepository PersonRepository { get; }
        IEmployeeRepository EmployeeRepository { get; }
        IRoomRepository RoomRepository { get; }
        #endregion

        #region DOC

        #endregion

        #region SYS
        IAccountRepository AccountRepository { get; }
        IRoleRepository RoleRepository { get; }
        IUserRepository UserRepository { get; }
        #endregion
    }
}
