using Global.Models;
using System.Linq.Dynamic.Core;

namespace OnApp.BizLayer.PersonServices;
public static class PersonListDtoSortFilter
{
    public static IQueryable<PersonListDto> SortFilter(
          this IQueryable<PersonListDto> query,
          ISortFilterOptions options
          )
    {
        if (options.HasSearch())
            query = query.Where(position
                                    => position.Pinfl.Contains(options.Search,
                                                               StringComparison.OrdinalIgnoreCase) ||
                                       position.FullName.Contains(options.Search,
                                                                  StringComparison.OrdinalIgnoreCase) ||
                                       position.StateName.Contains(options.Search,
                                                                   StringComparison.OrdinalIgnoreCase) ||
                                       position.DocumentTypeName.Contains(options.Search,
                                                                   StringComparison.OrdinalIgnoreCase) ||
                                       position.DocumentSeria.Contains(options.Search,
                                                                   StringComparison.OrdinalIgnoreCase) ||
                                       position.DocumentNumber.Contains(options.Search,
                                                                   StringComparison.OrdinalIgnoreCase)
                                );

        if (options.HasSort())
            query = query.OrderBy($"{options.SortBy} {options.OrderType}");
        else
            query = query.OrderByDescending(position => position.Id);

        return query;
    }
}
