using OnApp.DataLayer.Repository;
using Global;
using Global.Models;
using StatusGeneric;

namespace OnApp.BizLayer.DistrictServices
{
    public class DistrictService :
        StatusGenericHandler,
        IDistrictService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IDistrictRepository repository;
        public DistrictService(
            IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            repository = unitOfWork.DistrictRepository;
        }

        public PagedResult<DistrictListDto> GetDistrictList(SortFilterPageOptions options)
        {
            var result = repository.ReadAsNoTracked<DistrictListDto>();

            return result.SortFilter(options)
                            .AsPagedResult(options);
        }

        public SelectList<int> GetDistrictAsSelectList()
            => repository.AllAsQueryable
                             .AsSelectList();

        public DistrictDto GetDistrict()
            => new DistrictDto();

        public DistrictDto GetDistrictById(int districtId)
        {
            var DistrictDto 
                = repository.ById<DistrictDto>(districtId);

            CombineStatuses(repository);

            if (HasErrors)
                return null;

            return DistrictDto;
        }

        public HaveId<int> CreateDistrict(CreateDistrictDlDto dto)
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

        public void UpdateDistrict(UpdateDistrictDlDto dto)
        {
            repository.Update(dto);

            CombineStatuses(repository);

            if (IsValid)
                unitOfWork.Save();
        }

        public void DeleteDistrict(int Id)
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
