using OnApp.Core.Security;
using GenericServices;
using Global.EF;

namespace OnApp.DataLayer.Repository
{
    public class RoomRepository :
        BaseEntityRepository<int, Room, CreateRoomDlDto, UpdateRoomDlDto>,
        IRoomRepository
    {
        private readonly IAuthService authService;

        public RoomRepository(
            ICrudServices crudServices,
            IAuthService authService)
            : base(crudServices)
        {
            this.authService = authService;
        }

        protected override void OnCreate(Room entity, CreateRoomDlDto dto)
            => SetEntityProperties(entity, dto);

        protected override void OnUpdate(Room entity, UpdateRoomDlDto dto)
            => SetEntityProperties(entity, dto);
        private void SetEntityProperties<TDto>(Room entity, RoomDlDto<TDto> dto)
            where TDto : RoomDlDto<TDto>
        {
            entity.OrganizationId = authService.Organization.Id;
        }
    }
}
