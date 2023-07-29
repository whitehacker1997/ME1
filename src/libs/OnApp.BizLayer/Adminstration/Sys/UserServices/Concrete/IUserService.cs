using OnApp.DataLayer.Repository;
using Global.Models;
using StatusGeneric;

namespace OnApp.BizLayer.UserServices;

public interface IUserService : 
    IStatusGeneric
{
    PagedResult<UserListDto> GetUserList(SortFilterPageOptions options);
    UserDto GetUser();
    UserDto GetUserById(int userId);
    CreateUserDto GetUserByDocInfo(UserDocInfoDto dto);
    PagedSelectList<int> GetUserAsSelectList(UserSortFilterPageOptions options);
    HaveId<int> CreateUser(CreateUserDto dto);
    HaveId<int> CreateUserByEmployee(CreateByEmployeeDlDto dto);
    void UpdateUser(UpdateUserDlDto dto);
    void DeleteUser(int userId);
    bool IsUserNameBusy(CheckUserNameDto dto);
}
