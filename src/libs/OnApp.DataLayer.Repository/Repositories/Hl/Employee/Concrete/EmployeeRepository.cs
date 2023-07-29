using OnApp.Core.Security;
using GenericServices;
using Global;
using Global.EF;
using Microsoft.EntityFrameworkCore;

namespace OnApp.DataLayer.Repository
{
    public class EmployeeRepository :
        BaseEntityRepository<int, Employee, CreateEmployeeDlDto, UpdateEmployeeDlDto>,
        IEmployeeRepository
    {
        private readonly ICrudServices crudServices;
        private readonly IAuthService authService;

        public EmployeeRepository(
            ICrudServices crudServices,
            IAuthService authService)
            : base(crudServices)
        {
            this.crudServices = crudServices;
            this.authService = authService;
        }

        protected override IQueryable<Employee> ByIdQuery()
            => base.ByIdQuery().Include(employee => employee.User)
                                .ThenInclude(user => user.UserRoles)
                                .Include(employee => employee.Person);
        protected override void OnCreate(Employee entity,
                                         CreateEmployeeDlDto dto)
        {
            Validate(null, dto);
            SetEntityProperties(entity, dto);
        }

        protected override void OnUpdate(Employee entity,
                                         UpdateEmployeeDlDto dto)
        {
            Validate(entity, dto);
            SetEntityProperties(entity, dto);
        }

        private void SetEntityProperties<TDto>(Employee entity,
                                               EmployeeDlDto<TDto> dto)
            where TDto : EmployeeDlDto<TDto>
        {
            entity.OrganizationId = authService.Organization.Id;
            entity.ParentOrganizationId = authService.Organization.ParentId;
        }

        private void Validate<TDto>(Employee entity,
                                    EmployeeDlDto<TDto> dto)
            where TDto : EmployeeDlDto<TDto>
        {
            var query = DbSet.Include(employee => employee.User)
                             .Include(employee => employee.Person)
                                .AsQueryable();

            if (entity != null)
                query = query.Where(employee => employee.Id != entity.Id);

            var employee = query.IsActive()
                                .FirstOrDefault(employee => employee.PersonId == dto.PersonId &&
                                                            employee.PositionId == dto.PositionId &&
                                                            employee.OrganizationId == authService.Organization.Id);

            if (employee != null)
                AddError(errorMessage: $"Это сотрудник уже существует.", $"{employee.Person.DocumentSeria}{employee.Person.DocumentNumber}");

            var hasPhoneNumber = query.Any(person => person.PhoneNumber == dto.PhoneNumber && 
                                                     person.OrganizationId == authService.Organization.Id);

            if (hasPhoneNumber)
                AddError($"Этот ({dto.PhoneNumber}) номер телефона уже есть в системе");
        }

        protected override IQueryable<Employee> InjectFilter(IQueryable<Employee> query)
            => query.Where(employee => employee.OrganizationId == authService.Organization.Id);
    }
}
