using System.Linq.Dynamic.Core;
using Global.Models;

namespace OnApp.BizLayer.NationalityServices
{
    public static class NationalityListDtoSortFilter
    {
        public static IQueryable<NationalityListDto> SortFilter(
            this IQueryable<NationalityListDto> query,
            ISortFilterOptions options
            )
        {
            if (options.HasSearch())
                query = query.Where(nationality
                                        => nationality.ShortName.Contains(options.Search, StringComparison.OrdinalIgnoreCase) ||
                                           nationality.FullName.Contains(options.Search, StringComparison.OrdinalIgnoreCase) ||
                                           nationality.StateName.Contains(options.Search, StringComparison.OrdinalIgnoreCase)
                                    );

            if (options.HasSort())
                query = query.OrderBy($"{options.SortBy} {options.OrderType}");
            else
                query = query.OrderByDescending(nationality => nationality.Id);

            return query;
        }
    }
}
