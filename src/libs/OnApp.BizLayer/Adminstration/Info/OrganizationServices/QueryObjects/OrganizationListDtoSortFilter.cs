using System.Linq.Dynamic.Core;
using Global.Models;

namespace OnApp.BizLayer.OrganizationServices
{
    public static class OrganizationListDtoSortFilter
    {
        public static IQueryable<OrganizationListDto> SortFilter(
            this IQueryable<OrganizationListDto> query,
            ISortFilterOptions options
            )
        {
            if (options.HasSearch())
                query = query.Where(region
                                        => region.ShortName.Contains(options.Search, StringComparison.OrdinalIgnoreCase) ||
                                           region.FullName.Contains(options.Search, StringComparison.OrdinalIgnoreCase) ||
                                           region.StateName.Contains(options.Search, StringComparison.OrdinalIgnoreCase) ||
                                           region.CountryName.Contains(options.Search,StringComparison.OrdinalIgnoreCase) ||
                                           region.ParentName.Contains(options.Search, StringComparison.OrdinalIgnoreCase) ||
                                           region.Inn.Contains(options.Search, StringComparison.OrdinalIgnoreCase) ||
                                           region.PhoneNumber.Contains(options.Search, StringComparison.OrdinalIgnoreCase) ||
                                           region.Director.Contains(options.Search, StringComparison.OrdinalIgnoreCase) ||
                                           region.RegionName.Contains(options.Search, StringComparison.OrdinalIgnoreCase) ||
                                           region.DistrictName.Contains(options.Search, StringComparison.OrdinalIgnoreCase)
                                    );

            if (options.HasSort())
                query = query.OrderBy($"{options.SortBy} {options.OrderType}");
            else
                query = query.OrderByDescending(region => region.Id);

            return query;
        }
    }
}
