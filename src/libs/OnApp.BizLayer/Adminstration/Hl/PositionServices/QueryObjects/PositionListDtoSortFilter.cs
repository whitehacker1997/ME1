using System.Linq.Dynamic.Core;
using Global.Models;

namespace OnApp.BizLayer.PositionServices
{
    public static class PositionListDtoSortFilter
    {
        public static IQueryable<PositionListDto> SortFilter(
            this IQueryable<PositionListDto> query,
            ISortFilterOptions options
            )
        {
            if (options.HasSearch())
                query = query.Where(position
                                        => position.ShortName.Contains(options.Search, StringComparison.OrdinalIgnoreCase) ||
                                           position.FullName.Contains(options.Search, StringComparison.OrdinalIgnoreCase) ||
                                           position.StateName.Contains(options.Search, StringComparison.OrdinalIgnoreCase)
                                    );

            if (options.HasSort())
                query = query.OrderBy($"{options.SortBy} {options.OrderType}");
            else
                query = query.OrderByDescending(position => position.Id);

            return query;
        }
    }
}
