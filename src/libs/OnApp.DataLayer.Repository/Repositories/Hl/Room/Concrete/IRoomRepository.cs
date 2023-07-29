using Global.EF;

namespace OnApp.DataLayer.Repository
{
    public interface IRoomRepository :
        IBaseEntityRepository<int, Room, CreateRoomDlDto, UpdateRoomDlDto>
    {
    }
}
