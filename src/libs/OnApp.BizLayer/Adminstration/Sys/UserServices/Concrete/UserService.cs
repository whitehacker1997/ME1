using OnApp.Core.Security;
using OnApp.DataLayer.Repository;
using Global;
using Global.Models;
using Microsoft.EntityFrameworkCore;
using StatusGeneric;

namespace OnApp.BizLayer.UserServices;

public class UserService :
    StatusGenericHandler,
    IUserService
{
    private readonly IUserRepository repository;
    private readonly IUnitOfWork unitOfWork;
    private readonly IAuthService authService;

    public UserService(
        IUnitOfWork unitOfWork,
        IAuthService authService
        )
    {
        repository = unitOfWork.UserRepository;
        this.unitOfWork = unitOfWork;
        this.authService = authService;
    }
    private IQueryable<TDto> GetQuery<TDto>()
            where TDto : class
    {
        if (authService.HasPermission(ModuleCode.AllUserView))
            return repository.ReadAsNoTracked<TDto>();

        if (authService.HasPermission(ModuleCode.BranchesUserView))
            return repository.ReadAsNoTracked<TDto>(user => user.Organization.ParentId == authService.User.ParentOrganizationId);

        return repository.ReadAsNoTracked<TDto>(user => user.Organization.ParentId == authService.User.ParentOrganizationId &&
                                                        user.OrganizationId == authService.User.OrganizationId);
    }
    public PagedResult<UserListDto> GetUserList(SortFilterPageOptions options)
        => GetQuery<UserListDto>()
            .SortFilter(options)
                .AsPagedResult(options);
    
    public UserDto GetUser()
        => new UserDto();
    
    public PagedSelectList<int> GetUserAsSelectList(UserSortFilterPageOptions options)
        => GetQuery<UserListDto>()
             .AsPagedResult(options)
                .AsSelectList();
    
    public CreateUserDto GetUserByDocInfo(UserDocInfoDto dto)
        => repository.ReadAsNoTracked<CreateUserDto>()
                        .FirstOrDefault(user => user.Person.DocumentSeria == dto.DocumentSeria &&
                                                user.Person.DocumentNumber == dto.DocumentNumber &&
                                                user.Person.DocumentTypeId == dto.DocumentTypeId);

    public UserDto GetUserById(int userId)
    {
        var userDto = GetQuery<UserDto>().
                        FirstOrDefault(user => user.Id == userId);

        if (userDto == null)
            AddError(errorMessage: "По вашему запросу запись не найдено");

        return userDto!;
    }
    
    public HaveId<int> CreateUser(CreateUserDto dto)
    {
        var organization = unitOfWork.Context.Set<Organization>()
                                                .FirstOrDefault(organization => organization.Id == dto.OrganizationId);

        if ((!authService.HasPermission(ModuleCode.AllUserCreate, ModuleCode.BranchesUserCreate) &&
             organization.ParentId != authService.User.ParentOrganizationId &&
             dto.OrganizationId != authService.User.OrganizationId) ||
             (!authService.HasPermission(ModuleCode.AllUserCreate) &&
             organization.ParentId != authService.User.ParentOrganizationId))
        {
            AddError("У вас нет разрешения на создание пользователя другой организации");
            return null;
        }

        Person person = unitOfWork.PersonRepository.ByDocInfo(docTypeId: dto.Person.DocumentTypeId,
                                                              docSeria: dto.Person.DocumentSeria,
                                                              docNumber: dto.Person.DocumentNumber);

        if (person == null)
        {
            person = unitOfWork.PersonRepository.Create(dto.Person);
            CombineStatuses(unitOfWork.PersonRepository);
        }

        if (IsValid)
        {
            var entity = repository.Create(dto);

            entity.Person = person;
            entity.PersonId = person.Id;
            
            CombineStatuses(repository);

            if (IsValid)
            {
                unitOfWork.Save();

                return HaveId.Create(entity.Id);
            }
        }

        return null;
    }
    
    public HaveId<int> CreateUserByEmployee(CreateByEmployeeDlDto dto)
    {
        var organization = unitOfWork.Context.Set<Organization>()
                                                .FirstOrDefault(organization => organization.Id == dto.OrganizationId);

        if ((!authService.HasPermission(ModuleCode.AllUserCreate, ModuleCode.BranchesUserCreate)
                   && organization.ParentId != authService.User.ParentOrganizationId
                   && dto.OrganizationId != authService.User.OrganizationId)
               || (!authService.HasPermission(ModuleCode.AllUserCreate)
                   && organization.ParentId != authService.User.ParentOrganizationId))
        {
            AddError("У вас нет разрешения на создание пользователя другой организации");
            return null;
        }

        var entity = repository.Create(dto);
        CombineStatuses(repository);

        if (IsValid)
        {
            unitOfWork.Save();
        
            return HaveId.Create(entity.Id);
        }

        return null;
    }
    
    public void UpdateUser(UpdateUserDlDto dto)
    {
        var organization = unitOfWork.Context.Set<Organization>()
                                                .FirstOrDefault(organization => organization.Id == dto.OrganizationId);

        if ((!authService.HasPermission(ModuleCode.AllUserEdit, ModuleCode.BranchesUserEdit)
                  && organization.ParentId != authService.User.ParentOrganizationId
                  && dto.OrganizationId != authService.User.OrganizationId)
              || (!authService.HasPermission(ModuleCode.AllUserEdit)
                  && organization.ParentId != authService.User.ParentOrganizationId))
        {
            AddError("У вас нет разрешения на редактирование пользователя другой организации");
            return;
        }

        repository.Update(dto);
        CombineStatuses(repository);

        if (IsValid)
            unitOfWork.Save();
    }
    
    public void DeleteUser(int userId)
    {
        var entity = repository.ById(userId);
        var organization = unitOfWork.Context.Set<Organization>()
                                                .FirstOrDefault(organization => organization.Id == entity.OrganizationId);

        if ((!authService.HasPermission(ModuleCode.AllUserDelete, ModuleCode.BranchesUserDelete)
               && organization.ParentId != authService.User.ParentOrganizationId
               && entity.OrganizationId != authService.User.OrganizationId)
           || (!authService.HasPermission(ModuleCode.AllUserDelete)
               && organization.ParentId != authService.User.ParentOrganizationId))
        {
            AddError("У вас нет разрешения на удаление пользователя другой организации");
            return;
        }
        try
        {
            repository.Delete(userId);
            CombineStatuses(repository);

            if (IsValid)
                unitOfWork.Save();
        }
        catch (DbUpdateException)
        {
            AddError("Пользователь не может быть удален");
        }
    }

    public bool IsUserNameBusy(CheckUserNameDto dto)
    {
        var user = repository.ByUserName(dto.UserName);

        return user != null &&
               user.Id != dto.Id;
    }
}
