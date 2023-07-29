using GenericServices;
using Global;
using Global.EF;

namespace OnApp.DataLayer.Repository
{
    public class PersonRepository :
        BaseEntityRepository<int, Person, CreatePersonDlDto, UpdatePersonDlDto>,
        IPersonRepository
    {
        public PersonRepository(ICrudServices crudServices)
            : base(crudServices)
        {

        }

        public Person ByDocInfo(int docTypeId, string docSeria, string docNumber)
            => ByIdQuery().FirstOrDefault(person => person.DocumentTypeId == docTypeId &&
                                                    person.DocumentSeria == docSeria &&
                                                    person.DocumentNumber == docNumber);

        public Person ByPinfl(string pinfl)
            => ByIdQuery().FirstOrDefault(person => person.Pinfl == pinfl);

        protected override void CreateValidate(CreatePersonDlDto dto)
            => Validate(entity: null, dto: dto);

        protected override void UpdateValidate(Person entity,
                                               UpdatePersonDlDto dto)
            => Validate(entity: null, dto: dto);

        private void Validate<TDto>(Person entity,
                                    PersonDlDto<TDto> dto)
            where TDto : PersonDlDto<TDto>
        {
            var query = DbSet.AsQueryable();

            if (entity != null)
                query = query.Where(a => a.Id != entity.Id);

            if (query.Any(person => person.DocumentTypeId == dto.DocumentTypeId &&
                                    person.DocumentNumber == dto.DocumentNumber &&
                                    person.DocumentSeria == dto.DocumentSeria))
                    AddError($"Человек с этим информация о документе ({dto.DocumentSeria}{dto.DocumentNumber}) уже существует.");

            if (!dto.Inn.NullOrEmpty() && query.ByInn(dto.Inn, isIncludePassive: true).Any())
                AddError($"Человек с этим ИНН ({dto.Inn}) уже существует.", nameof(dto.Inn));

            if (!dto.Pinfl.NullOrEmpty() && query.ByPinfl(dto.Pinfl, isIncludePassive: true).Any())
                AddError($"Человек с этим ИНПС ({dto.Pinfl}) уже существует.", nameof(dto.Pinfl));
        }

    }
}
