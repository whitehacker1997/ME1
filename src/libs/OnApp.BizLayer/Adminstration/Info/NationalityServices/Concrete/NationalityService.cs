using OnApp.DataLayer.Repository;
using Global;
using Global.Models;
using StatusGeneric;

namespace OnApp.BizLayer.NationalityServices
{
    public class NationalityService :
        StatusGenericHandler,
        INationalityService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly INationalityRepository repository;
        public NationalityService(
            IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            repository = unitOfWork.NationalityRepository;
        }

        public PagedResult<NationalityListDto> GetNationalityList(SortFilterPageOptions options)
        {
            var result = repository.ReadAsNoTracked<NationalityListDto>();

            return result.SortFilter(options)
                            .AsPagedResult(options);
        }

        public SelectList<int> GetNationalityAsSelectList()
            => repository.AllAsQueryable
                             .AsSelectList();

        public NationalityDto GetNationality()
            => new NationalityDto();

        public NationalityDto GetNationalityById(int nationalityId)
        {
            var nationalityDto 
                = repository.ById<NationalityDto>(nationalityId);

            CombineStatuses(repository);

            if (HasErrors)
                return null;

            return nationalityDto;
        }

        public HaveId<int> CreateNationality(CreateNationalityDlDto dto)
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

        public void UpdateNationality(UpdateNationalityDlDto dto)
        {
            repository.Update(dto);

            CombineStatuses(repository);

            if (IsValid)
                unitOfWork.Save();
        }

        public void DeleteNationality(int Id)
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
