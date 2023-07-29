using StatusGeneric;
using Microsoft.EntityFrameworkCore;
using OnApp.DataLayer.Repository;
using OnApp.Core.Security;
using Global.Models;
using Global;

namespace OnApp.BizLayer.RoleServices
{
    public class RoleService : 
        StatusGenericHandler,
        IRoleService
    {
        private readonly IRoleRepository repository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IAuthService authService;

        public RoleService(IUnitOfWork unitOfWork,
                           IAuthService authService)
        {
            repository = unitOfWork.RoleRepository;
            this.unitOfWork = unitOfWork;
            this.authService = authService;
        }

        public PagedResult<RoleListDto> GetRoleList(SortFilterPageOptions dto)
        {
            var result = repository.ReadAsNoTracked<RoleListDto>()
                            .SortFilter(dto)
                            .AsPagedResult(dto);
            return result;
        }

        public RoleDto GetRole()
            => new RoleDto();

        public RoleDto GetRoleById(int id)
        {
            var dto = repository.ById<RoleDto>(id);
            CombineStatuses(repository);

            return dto;
        }

        public SelectList<int> GetRoleAsSelectList()
            => repository.AllAsQueryable
                            .AsSelectList();

        public HaveId<int> CreateRole(CreateRoleDlDto dto)
        {
            var entity = repository.Create(dto);
            CombineStatuses(repository);
            
            if (IsValid)
            {
                unitOfWork.Save();
                return HaveId.Create(entity.Id);
            }


            return null;
        }

        public void UpdateRole(UpdateRoleDlDto dto)
        {
            repository.Update(dto);
            CombineStatuses(repository);

            if (IsValid)
                unitOfWork.Save();
        }

        public void DeleteRole(int id)
        {
            try
            {
                repository.Delete(id);
                CombineStatuses(repository);

                if (IsValid)
                    unitOfWork.Save();
            }
            catch (DbUpdateException)
            {
                AddError("������ �� ����� ���� ������");
            }
        }

    }
}
