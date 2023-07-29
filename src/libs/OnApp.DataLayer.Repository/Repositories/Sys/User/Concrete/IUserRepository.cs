using Global.EF;

namespace OnApp.DataLayer.Repository;

public interface IUserRepository : 
    IBaseEntityRepository<int, User, CreateUserDlDto, UpdateUserDlDto>
{
    User ByUserName(string userName);
    User Create(CreateByEmployeeDlDto dto);
}
