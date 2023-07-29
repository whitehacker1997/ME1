using OnApp.DataLayer.Repository;
using Global;
using Global.Models;
using StatusGeneric;

namespace OnApp.BizLayer.OrganizationServices
{
    public class OrganizationService :
        StatusGenericHandler,
        IOrganizationService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IOrganizationRepository repository;

        public OrganizationService(
            IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            repository = unitOfWork.OrganizationRepository;
        }

        public PagedResult<OrganizationListDto> GetOrganizationList(SortFilterPageOptions options)
        {
            var result = repository.ReadAsNoTracked<OrganizationListDto>();

            return result.SortFilter(options)
                            .AsPagedResult(options);
        }

        public SelectList<int> GetOrganizationAsSelectList()
            => repository.AllAsQueryable
                             .AsSelectList();

        public OrganizationDto GetOrganization()
            => new OrganizationDto();

        public OrganizationDto GetOrganizationById(int organizationId)
        {
            var organizationDto 
                = repository.ById<OrganizationDto>(organizationId);

            CombineStatuses(repository);

            if (HasErrors)
                return null;

            return organizationDto;
        }

        public HaveId<int> CreateOrganization(CreateOrganizationDlDto dto)
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

        public void UpdateOrganization(UpdateOrganizationDlDto dto)
        {
            repository.Update(dto);

            CombineStatuses(repository);

            if (IsValid)
                unitOfWork.Save();
        }

        public void DeleteOrganization(int Id)
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
