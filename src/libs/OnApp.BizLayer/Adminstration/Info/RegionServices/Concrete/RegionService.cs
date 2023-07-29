using OnApp.DataLayer.Repository;
using Global;
using Global.Models;
using StatusGeneric;

namespace OnApp.BizLayer.RegionServices
{
    public class RegionService :
        StatusGenericHandler,
        IRegionService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IRegionRepository repository;
        public RegionService(
            IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            repository = unitOfWork.RegionRepository;
        }

        public PagedResult<RegionListDto> GetRegionList(SortFilterPageOptions options)
        {
            var result = repository.ReadAsNoTracked<RegionListDto>();

            return result.SortFilter(options)
                            .AsPagedResult(options);
        }

        public SelectList<int> GetRegionAsSelectList()
            => repository.AllAsQueryable
                             .AsSelectList();

        public RegionDto GetRegion()
            => new RegionDto();

        public RegionDto GetRegionById(int regionId)
        {
            var regionDto 
                = repository.ById<RegionDto>(regionId);

            CombineStatuses(repository);

            if (HasErrors)
                return null;

            return regionDto;
        }

        public HaveId<int> CreateRegion(CreateRegionDlDto dto)
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

        public void UpdateRegion(UpdateRegionDlDto dto)
        {
            repository.Update(dto);

            CombineStatuses(repository);

            if (IsValid)
                unitOfWork.Save();
        }

        public void DeleteRegion(int Id)
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
