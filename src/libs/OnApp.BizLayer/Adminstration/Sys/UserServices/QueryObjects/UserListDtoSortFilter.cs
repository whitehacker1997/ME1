using Global.Models;
using System.Linq.Dynamic.Core;

namespace OnApp.BizLayer.UserServices;

public static class UserListDtoSortFilter
{
    public static IQueryable<UserListDto> SortFilter(this IQueryable<UserListDto> query,
                                                     ISortFilterOptions options)
    {
        if (options.HasSearch())
            query = query.Where(userListDto => userListDto.FullName.Contains(options.Search,StringComparison.OrdinalIgnoreCase) || 
                                               userListDto.OrganizationName.Contains(options.Search,StringComparison.OrdinalIgnoreCase) ||
                                               userListDto.PhoneNumber.Contains(options.Search,StringComparison.OrdinalIgnoreCase));
                
        if (options.HasSort())
            query = query.OrderBy($"{options.SortBy} {options.OrderType}");
        else
            query = query.OrderByDescending(userListDto => userListDto.Id);

        return query;
    }

    public static IQueryable<UserListDto> FilterByCustomFields(this IQueryable<UserListDto> query,
                                                               UserSortFilterPageOptions options)
    {
        if (options.ParentOrganizationId.HasValue)
            query = query.Where(userListDto => userListDto.ParentOrganizationId == options.ParentOrganizationId);

        if (options.OrganizationId.HasValue)
            query = query.Where(userListDto => userListDto.OrganizationId == options.OrganizationId);

        return query;
    }
}
