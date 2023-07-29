using System.Linq.Dynamic.Core;
using Global.Models;

namespace OnApp.BizLayer.DistrictServices
{
    public static class DistrictListDtoSortFilter
    {
        public static IQueryable<DistrictListDto> SortFilter(
            this IQueryable<DistrictListDto> query,
            ISortFilterOptions options
            )
        {
            if (options.HasSearch())
                query = query.Where(district
                                        => district.ShortName.Contains(options.Search, StringComparison.OrdinalIgnoreCase) ||
                                           district.FullName.Contains(options.Search, StringComparison.OrdinalIgnoreCase) ||
                                           district.StateName.Contains(options.Search, StringComparison.OrdinalIgnoreCase) ||
                                           district.RegionName.Contains(options.Search,StringComparison.OrdinalIgnoreCase)
                                    );

            if (options.HasSort())
                query = query.OrderBy($"{options.SortBy} {options.OrderType}");
            else
                query = query.OrderByDescending(District => District.Id);

            return query;
        }
    }
}
