using OnApp.DataLayer.Repository;
using Global.Models;
using StatusGeneric;

namespace OnApp.BizLayer.RoomServices
{
    public interface IRoomService : 
        IStatusGeneric
    {
        PagedResult<RoomListDto> GetRoomList(SortFilterPageOptions options);
        SelectList<int> GetRoomAsSelectList();
        RoomDto GetRoom();
        RoomDto GetRoomById(int RoomId);
        HaveId<int> CreateRoom(CreateRoomDlDto dto);
        void UpdateRoom(UpdateRoomDlDto dto);
        void DeleteRoom(int RoomId);
    }
}
