using OnApp.DataLayer.Repository;
using Global;
using Global.Models;
using Microsoft.EntityFrameworkCore;
using StatusGeneric;

namespace OnApp.BizLayer.EmployeeServices
{
    public class EmployeeService :
        StatusGenericHandler,
        IEmployeeService
    {
        private readonly IEmployeeRepository repository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IPersonRepository personRepository;

        public EmployeeService(
            IUnitOfWork unitOfWork,
            IPersonRepository personRepository)
        {
            repository = unitOfWork.EmployeeRepository;
            this.unitOfWork = unitOfWork;
            this.personRepository = personRepository;
        }

        public PagedResult<EmployeeListDto> GetEmployeeList(SortFilterPageOptions filter)
            => repository.ReadAsNoTracked<EmployeeListDto>()
                                    .SortFilter(filter)
                                        .AsPagedResult(filter);
        public EmployeeDto GetEmployee()
            => new EmployeeDto();

        public EmployeeDto GetEmployeeById(int id)
        {
            var dto = repository.ById<EmployeeDto>(id);
            CombineStatuses(repository);

            return dto;
        }

        public SelectList<int> GetEmployeeAsSelectList(EmployeeSelectListFilterDto filter)
            => repository.ReadAsNoTracked<EmployeeListDto>()
                            .AsSelectList(filter);

        public HaveId<int> CreateEmployee(CreateEmployeeDlDto dto)
        {
            using (var transaction = unitOfWork.BeginTransaction())
            {
                try
                {
                    if (dto.Person != null)
                    {
                        if (dto.PersonId == 0)
                        {
                            var person = personRepository.Create(dto.Person);
                            CombineStatuses(personRepository);

                            if (HasErrors)
                            {
                                transaction.Rollback();
                                return null!;
                            }

                            unitOfWork.Save();

                            dto.PersonId = person.Id;
                        }

                        dto.Person = null!;
                    }

                    var entity = repository.Create(dto);
                    CombineStatuses(repository);

                    if (IsValid)
                    {
                        unitOfWork.Save();
                        transaction.Commit();

                        return HaveId.Create(entity.Id);
                    }

                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }

            return null!;
        }

        public void UpdateEmployee(UpdateEmployeeDlDto dto)
        {
            dto.Person = null!;
            repository.Update(dto);
            CombineStatuses(repository);

            if (IsValid)
                unitOfWork.Save();
        }

        public void DeleteEmployee(int id)
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
                AddError("Запись не может быть удален");
            }
        }
    }
}
