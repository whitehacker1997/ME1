using System.Linq.Dynamic.Core;
using Global.Models;

namespace OnApp.BizLayer.RegionServices
{
    public static class RegionListDtoSortFilter
    {
        public static IQueryable<RegionListDto> SortFilter(
            this IQueryable<RegionListDto> query,
            ISortFilterOptions options
            )
        {
            if (options.HasSearch())
                query = query.Where(region
                                        => region.ShortName.Contains(options.Search, StringComparison.OrdinalIgnoreCase) ||
                                           region.FullName.Contains(options.Search, StringComparison.OrdinalIgnoreCase) ||
                                           region.StateName.Contains(options.Search, StringComparison.OrdinalIgnoreCase) ||
                                           region.CountryName.Contains(options.Search,StringComparison.OrdinalIgnoreCase)
                                    );

            if (options.HasSort())
                query = query.OrderBy($"{options.SortBy} {options.OrderType}");
            else
                query = query.OrderByDescending(region => region.Id);

            return query;
        }
    }
}
