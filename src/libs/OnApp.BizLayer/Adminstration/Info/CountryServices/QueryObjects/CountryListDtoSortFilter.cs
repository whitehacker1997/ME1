using Global.Models;
using System.Linq.Dynamic.Core;

namespace OnApp.BizLayer.CountryServices
{
    public static class CountryListDtoSortFilter
    {
        public static IQueryable<CountryListDto> SortFilter(
            this IQueryable<CountryListDto> query,
            ISortFilterOptions options
            )
        {
            if (options.HasSearch())
                query = query.Where(country
                                        => country.ShortName.Contains(options.Search, StringComparison.OrdinalIgnoreCase) ||
                                           country.FullName.Contains(options.Search, StringComparison.OrdinalIgnoreCase) ||
                                           country.StateName.Contains(options.Search, StringComparison.OrdinalIgnoreCase)
                                    );

            if (options.HasSort())
                query = query.OrderBy($"{options.SortBy} {options.OrderType}");
            else
                query = query.OrderByDescending(country => country.Id);

            return query;
        }
    }
}
