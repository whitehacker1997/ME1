using OnApp.DataLayer.Repository;
using Global;
using Global.Models;
using StatusGeneric;

namespace OnApp.BizLayer.PositionServices
{
    public class PositionService :
        StatusGenericHandler,
        IPositionService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IPositionRepository repository;
        public PositionService(
            IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            repository = unitOfWork.PositionRepository;
        }

        public PagedResult<PositionListDto> GetPositionList(SortFilterPageOptions options)
        {
            var result = repository.ReadAsNoTracked<PositionListDto>();

            return result.SortFilter(options)
                            .AsPagedResult(options);
        }

        public SelectList<int> GetPositionAsSelectList()
            => repository.AllAsQueryable
                             .AsSelectList();

        public PositionDto GetPosition()
            => new PositionDto();

        public PositionDto GetPositionById(int positionId)
        {
            var positionDto 
                = repository.ById<PositionDto>(positionId);

            CombineStatuses(repository);

            if (HasErrors)
                return null;

            return positionDto;
        }

        public HaveId<int> CreatePosition(CreatePositionDlDto dto)
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

        public void UpdatePosition(UpdatePositionDlDto dto)
        {
            repository.Update(dto);

            CombineStatuses(repository);

            if (IsValid)
                unitOfWork.Save();
        }

        public void DeletePosition(int Id)
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
