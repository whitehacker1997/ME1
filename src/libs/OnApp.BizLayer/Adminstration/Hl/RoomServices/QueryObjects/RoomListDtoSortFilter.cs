using System.Linq.Dynamic.Core;
using Global.Models;

namespace OnApp.BizLayer.RoomServices
{
    public static class RoomListDtoSortFilter
    {
        public static IQueryable<RoomListDto> SortFilter(
            this IQueryable<RoomListDto> query,
            ISortFilterOptions options
            )
        {
            if (options.HasSearch())
                query = query.Where(Room
                                        => Room.RoomNumber.Contains(options.Search, StringComparison.OrdinalIgnoreCase) ||
                                           Room.StateName.Contains(options.Search, StringComparison.OrdinalIgnoreCase)
                                    );

            if (options.HasSort())
                query = query.OrderBy($"{options.SortBy} {options.OrderType}");
            else
                query = query.OrderByDescending(Room => Room.Id);

            return query;
        }
    }
}
