using GenericServices;
using Global;
using Global.EF;
using Microsoft.EntityFrameworkCore;

namespace OnApp.DataLayer.Repository
{
    public class NationalityRepository :
        BaseEntityRepository<int, Nationality, CreateNationalityDlDto, UpdateNationalityDlDto>,
        INationalityRepository

    {
        public NationalityRepository(ICrudServices crudServices) :
            base(crudServices)
        {
        }


        public Nationality ByWbCode(string wbCode)
        {
            if (wbCode.NullOrEmpty())
                return null;

            return ByIdQuery()
                    .FirstOrDefault(nationality => nationality.WbCode == wbCode)!;
        }

        protected override IQueryable<Nationality> ByIdQuery()
            => AllAsQueryable.Include(nationality => nationality.Translates);

        protected override void CreateValidate(CreateNationalityDlDto dto)
            => Validate(null, dto);

        protected override void UpdateValidate(Nationality entity, UpdateNationalityDlDto dto)
            => Validate(entity, dto);

        private void Validate<TDto>(Nationality entity, NationalityDlDto<TDto> dto)
            where TDto : NationalityDlDto<TDto>
        {
            var query = DbSet.AsQueryable();

            if (entity != null)
                query = query.Where(nationality => nationality.Id != entity.Id);

            if (string.IsNullOrWhiteSpace(dto.WbCode)
                && query.ByNumberCode(numberCode: dto.WbCode,
                                      isIncludePassive: true).Any())
                AddError($"Область с этим кодом ({dto.WbCode}) уже существует.", nameof(dto.WbCode));
        }
    }
}
