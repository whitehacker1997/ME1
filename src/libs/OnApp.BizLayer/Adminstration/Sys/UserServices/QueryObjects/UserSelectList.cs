using OnApp.BizLayer.UserServices;
using Global.Models;

namespace OnApp.BizLayer
{
    public static class UserSelectList
    {
        public static PagedSelectList<int> AsSelectList(this PagedResult<UserListDto> pagedResult)
        {
            return new PagedSelectList<int>(
                pagedResult,
                pagedResult
                    .Rows
                    .Select(userListDto => new SelectListItem<int>
                    {
                        Value = userListDto.Id,
                        Text = userListDto.FullName
                    }));
        }
    }
}
