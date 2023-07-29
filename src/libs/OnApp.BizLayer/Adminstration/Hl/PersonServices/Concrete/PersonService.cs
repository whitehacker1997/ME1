using StatusGeneric;
using Microsoft.EntityFrameworkCore;
using OnApp.DataLayer.Repository;
using Global.Models;
using Global;

namespace OnApp.BizLayer.PersonServices
{
    public class PersonService :
        StatusGenericHandler,
        IPersonService
    {
        private readonly IPersonRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public PersonService(IUnitOfWork unitOfWork)
        {
            repository = unitOfWork.PersonRepository;
            this.unitOfWork = unitOfWork;
        }

        public PagedResult<PersonListDto> GetPersonList(SortFilterPageOptions filter)
            => repository.ReadAsNoTracked<PersonListDto>()
                                    .SortFilter(filter)
                                        .AsPagedResult(filter);
        public PersonDto GetPerson()
            => new PersonDto();

        public PersonDto GetPersonById(int id)
        {
            var dto = repository.ById<PersonDto>(id);
            CombineStatuses(repository);

            return dto;
        }

        public SelectList<int> GetPersonAsSelectList()
            => repository.AllAsQueryable.AsSelectList();

        public HaveId<int> CreatePerson(CreatePersonDlDto dto)
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

        public void UpdatePerson(UpdatePersonDlDto dto)
        {
            repository.Update(dto);
            CombineStatuses(repository);

            if (IsValid)
                unitOfWork.Save();
        }

        public void DeletePerson(int id)
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
        public PersonDto GetPersonByDoc(string docSeria,
                                        string docNumber)
        {
            var person = repository.ReadAsNoTracked<PersonDto>()
                                    .FirstOrDefault(person => person.DocumentSeria == docSeria &&
                                                              person.DocumentNumber == docNumber);

            return person;
        }

    }
}
