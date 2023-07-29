using OnApp.DataLayer.Repository;
using Global;
using Global.Models;

namespace OnApp.BizLayer.RoomServices
{
    public static class RoomSelectList
    {
        public static SelectList<int> AsSelectList(this IQueryable<Room> room)
         => new SelectList<int>(
                room
                    .IsActive()
                    .Select(room => new SelectListItem<int>
                    {
                        Value = room.Id,
                        OrderCode = room.OrderCode,
                        Text = $"{room.Floor}/{room.RoomNumber}",
                    }).OrderBy(country => country.OrderCode)
                            .ThenBy(a => a.Text));
    }
}
