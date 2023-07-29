using GenericServices;
using Global;
using Global.EF;
using Microsoft.EntityFrameworkCore;

namespace OnApp.DataLayer.Repository
{
    public class CitizenshipRepository :
        BaseEntityRepository<int, Citizenship, CreateCitizenshipDlDto, UpdateCitizenshipDlDto>,
        ICitizenshipRepository

    {
        public CitizenshipRepository(ICrudServices crudServices) :
            base(crudServices)
        {
        }


        public Citizenship ByWbCode(string wbCode)
        {
            if (wbCode.NullOrEmpty())
                return null;

            return ByIdQuery()
                    .FirstOrDefault(citizenship => citizenship.WbCode == wbCode)!;
        }

        protected override IQueryable<Citizenship> ByIdQuery()
            => AllAsQueryable.Include(citizenship => citizenship.Translates);

        protected override void CreateValidate(CreateCitizenshipDlDto dto)
            => Validate(null, dto);

        protected override void UpdateValidate(Citizenship entity, UpdateCitizenshipDlDto dto)
            => Validate(entity, dto);

        private void Validate<TDto>(Citizenship entity, CitizenshipDlDto<TDto> dto)
            where TDto : CitizenshipDlDto<TDto>
        {
            var query = DbSet.AsQueryable();

            if (entity != null)
                query = query.Where(citizenship => citizenship.Id != entity.Id);

            if (string.IsNullOrWhiteSpace(dto.WbCode)
                && query.ByNumberCode(numberCode: dto.WbCode,
                                      isIncludePassive: true).Any())
                AddError($"Область с этим кодом ({dto.WbCode}) уже существует.", nameof(dto.WbCode));
        }
    }
}
