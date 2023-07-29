using Global.Models;
using System.Linq.Dynamic.Core;

namespace OnApp.BizLayer.EmployeeServices;

public static class EmployeeListDtoSortFilter
{
    public static IQueryable<EmployeeListDto> SortFilter(this IQueryable<EmployeeListDto> query, ISortFilterOptions options)
    {
        if (options.HasSearch())
            query = query.Where(a => a.FullName.ToLower().Contains(options.Search.ToLower()));

        if (options.HasSort())
            query = query.OrderBy($"{options.SortBy} {options.OrderType}");
        else
            query = query.OrderByDescending(a => a.Id);

        return query;
    }

    /*public static IQueryable<EmployeeListDto> FilterByCustomFields(this IQueryable<EmployeeListDto> query, EmployeeSortFilterPageOptions options)
    {
        if (options.ParentOrganizationId.HasValue)
            query = query.Where(a => a.ParentOrganizationId == options.ParentOrganizationId);

        if (options.OrganizationId.HasValue && options.ParentOrganizationId.Value != options.OrganizationId.Value)
            query = query.Where(a => a.OrganizationId == options.OrganizationId);

        return query;
    }*/
}
