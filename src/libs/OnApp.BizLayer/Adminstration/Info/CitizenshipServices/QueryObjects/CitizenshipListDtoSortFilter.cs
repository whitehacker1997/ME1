using System.Linq.Dynamic.Core;
using Global.Models;

namespace OnApp.BizLayer.CitizenshipServices
{
    public static class CitizenshipListDtoSortFilter
    {
        public static IQueryable<CitizenshipListDto> SortFilter(
            this IQueryable<CitizenshipListDto> query,
            ISortFilterOptions options
            )
        {
            if (options.HasSearch())
                query = query.Where(citizenship
                                        => citizenship.ShortName.Contains(options.Search, StringComparison.OrdinalIgnoreCase) ||
                                           citizenship.FullName.Contains(options.Search, StringComparison.OrdinalIgnoreCase) ||
                                           citizenship.StateName.Contains(options.Search, StringComparison.OrdinalIgnoreCase)
                                    );

            if (options.HasSort())
                query = query.OrderBy($"{options.SortBy} {options.OrderType}");
            else
                query = query.OrderByDescending(citizenship => citizenship.Id);

            return query;
        }
    }
}
