using OnApp.Core;
using Global.Attributes;
using Global.EF;

namespace OnApp.DataLayer.Repository
{
    public class RoomDlDto<TDto> :
        EntityDto<TDto, Room>
        where TDto : RoomDlDto<TDto>
    {
        public string? OrderCode { get; set; }
        public int? Floor { get; set; }
        [LocalizedRequired]
        [LocalizedStringLength(250)]
        public string RoomNumber { get; set; } = null!;
        public override Room CreateEntity()
        {
            var entity = base.CreateEntity();
            entity.StateId = StateIdConst.ACTIVE;

            return entity;
        }
    }
}
