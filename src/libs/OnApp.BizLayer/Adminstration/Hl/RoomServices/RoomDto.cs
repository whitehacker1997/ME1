using OnApp.DataLayer.Repository;

namespace OnApp.BizLayer.RoomServices
{
    public class RoomDto :
        UpdateRoomDlDto
    {
        public string OrganizationName { get; set; } = null!;
        public string StateName { get; set; } = null!;
    }
}
