using Global.Models;
using System.Linq.Dynamic.Core;

namespace OnApp.BizLayer.RoleServices
{
    public static class RoleListDtoSortFilter
    {
        public static IQueryable<RoleListDto> SortFilter(this IQueryable<RoleListDto> query,
                                                         ISortFilterOptions options)
        {
            if (options.HasSearch())
                query = query.Where(dto => dto.ShortName.Contains(options.Search, StringComparison.OrdinalIgnoreCase) ||
                                           dto.FullName.Contains(options.Search, StringComparison.OrdinalIgnoreCase));

            if (options.HasSort())
                query = query.OrderBy($"{options.SortBy} {options.OrderType}");
            else
                query = query.OrderByDescending(dto => dto.Id);

            return query;
        }
    }
}
