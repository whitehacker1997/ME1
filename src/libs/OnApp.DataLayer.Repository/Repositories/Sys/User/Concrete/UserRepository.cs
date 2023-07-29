using GenericServices;
using Global.EF;
using Microsoft.EntityFrameworkCore;

namespace OnApp.DataLayer.Repository;

public class UserRepository :
    BaseEntityRepository<int, User, CreateUserDlDto, UpdateUserDlDto>,
    IUserRepository
{
    public UserRepository(ICrudServices crudServices)
        : base(crudServices)
    {
    }

    protected override IQueryable<User> ByIdQuery()
        => base.ByIdQuery()
               .Include(user => user.UserRoles)
                    .ThenInclude(userRole => userRole.Role);

    public User Create(CreateByEmployeeDlDto dto)
    {
        var employee = CrudServices.Context.Set<Employee>()
                                                .Include(employee => employee.Person)
                                                .FirstOrDefault(employee => employee.Id == dto.EmployeeId);
        if (employee == null)
        {
            AddError("Сотрудник не найден");
            return null;
        }

        var query = DbSet.AsQueryable();
        
        if (query.Any(user => user.UserName == dto.UserName))
        {
            AddError("Это имя пользователя занято",
                     dto.UserName);

            return null;
        }

        var entity = dto.CreateEntity();
        entity.PersonId = employee.PersonId;
       
        DbSet.Add(entity);

        Context.Entry(entity).State = EntityState.Added;

        return entity;
    }

    public User ByUserName(string userName)
    {
        var user = ByIdQuery().FirstOrDefault(user => user.UserName == userName);

        if (user == null)
            AddEntityNotFoundError();

        return user;
    }

    protected override void OnCreate(User entity,
                                     CreateUserDlDto dto)
        => Validate(null, dto);

    protected override void OnUpdate(User entity,
                                     UpdateUserDlDto dto)
        => Validate(entity, dto);

    private void Validate<TDto>(User entity,
                            UserDlDto<TDto> dto)
    where TDto : UserDlDto<TDto>
    {
        var query = DbSet.AsQueryable();

        if (entity != null)
            query = query.Where(user => user.Id != entity.Id);

        if (!string.IsNullOrEmpty(dto.Email) && query.ByEmail(email : dto.Email, 
                                                              isIncludePassive: true).Any())
            AddError($"Ползователь с этим Email ({dto.Email}) уже существует.", nameof(dto.Email));
    }
}
