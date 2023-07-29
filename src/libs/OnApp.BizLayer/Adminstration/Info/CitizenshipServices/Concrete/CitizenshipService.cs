using OnApp.DataLayer.Repository;
using Global;
using Global.Models;
using StatusGeneric;

namespace OnApp.BizLayer.CitizenshipServices
{
    public class CitizenshipService :
        StatusGenericHandler,
        ICitizenshipService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ICitizenshipRepository repository;
        public CitizenshipService(
            IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            repository = unitOfWork.CitizenshipRepository;
        }

        public PagedResult<CitizenshipListDto> GetCitizenshipList(SortFilterPageOptions options)
        {
            var result = repository.ReadAsNoTracked<CitizenshipListDto>();

            return result.SortFilter(options)
                            .AsPagedResult(options);
        }

        public SelectList<int> GetCitizenshipAsSelectList()
            => repository.AllAsQueryable
                             .AsSelectList();

        public CitizenshipDto GetCitizenship()
            => new CitizenshipDto();

        public CitizenshipDto GetCitizenshipById(int citizenshipId)
        {
            var citizenshipDto 
                = repository.ById<CitizenshipDto>(citizenshipId);

            CombineStatuses(repository);

            if (HasErrors)
                return null;

            return citizenshipDto;
        }

        public HaveId<int> CreateCitizenship(CreateCitizenshipDlDto dto)
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

        public void UpdateCitizenship(UpdateCitizenshipDlDto dto)
        {
            repository.Update(dto);

            CombineStatuses(repository);

            if (IsValid)
                unitOfWork.Save();
        }

        public void DeleteCitizenship(int Id)
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
