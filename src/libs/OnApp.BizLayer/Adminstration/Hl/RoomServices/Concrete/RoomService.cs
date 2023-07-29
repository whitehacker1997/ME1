using OnApp.DataLayer.Repository;
using Global;
using Global.Models;
using StatusGeneric;

namespace OnApp.BizLayer.RoomServices
{
    public class RoomService :
        StatusGenericHandler,
        IRoomService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IRoomRepository repository;
        public RoomService(
            IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            repository = unitOfWork.RoomRepository;
        }

        public PagedResult<RoomListDto> GetRoomList(SortFilterPageOptions options)
        {
            var result = repository.ReadAsNoTracked<RoomListDto>();

            return result.SortFilter(options)
                            .AsPagedResult(options);
        }

        public SelectList<int> GetRoomAsSelectList()
            => repository.AllAsQueryable
                             .AsSelectList();

        public RoomDto GetRoom()
            => new RoomDto();

        public RoomDto GetRoomById(int RoomId)
        {
            var RoomDto 
                = repository.ById<RoomDto>(RoomId);

            CombineStatuses(repository);

            if (HasErrors)
                return null;

            return RoomDto;
        }

        public HaveId<int> CreateRoom(CreateRoomDlDto dto)
        {
            var entity =
                repository.Create(dto);

            CombineStatuses(repository);

            if (IsValid)
            {
                unitOfWork.Save();
                return HaveId.Create(entity.Id);
            }
            return null!;
        }

        public void UpdateRoom(UpdateRoomDlDto dto)
        {
            repository.Update(dto);

            CombineStatuses(repository);

            if (IsValid)
                unitOfWork.Save();
        }

        public void DeleteRoom(int Id)
        {
            try
            {
                repository.Delete(Id);
                CombineStatuses(repository);

                if (IsValid)
                    unitOfWork.Save();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
