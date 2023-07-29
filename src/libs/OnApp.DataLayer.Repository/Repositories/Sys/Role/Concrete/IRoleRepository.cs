using Global.EF;

namespace OnApp.DataLayer.Repository
{
    public interface IRoleRepository : 
        IBaseEntityRepository<int, Role, CreateRoleDlDto, UpdateRoleDlDto>
    {

    }
}
