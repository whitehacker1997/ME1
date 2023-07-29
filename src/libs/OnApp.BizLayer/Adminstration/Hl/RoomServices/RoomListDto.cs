using OnApp.DataLayer.Repository;
using GenericServices;

namespace OnApp.BizLayer.RoomServices
{
    public class RoomListDto : 
        ILinkToEntity<Room>
    {
        public int Id { get; set; }
        public string? OrderCode { get; set; }
        public int? Floor { get; set; }
        public string RoomNumber { get; set; } = null!;
        public int OrganizationId { get; set; }
        public string OrganizationName { get; set; } = null!;
        public int StateId { get; set; }
        public string StateName { get; set; } = null!;
    }
}
