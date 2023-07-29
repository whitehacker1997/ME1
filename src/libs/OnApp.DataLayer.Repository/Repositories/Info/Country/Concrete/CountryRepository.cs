using GenericServices;
using Global;
using Global.EF;
using Microsoft.EntityFrameworkCore;

namespace OnApp.DataLayer.Repository
{
    public class CountryRepository :
        BaseEntityRepository<int, Country, CreateCountryDlDto, UpdateCountryDlDto>,
        ICountryRepository
    {
        public CountryRepository(ICrudServices crudServices)
            : base(crudServices)
        { }

        public Country ByWbCode(string wbCode)
        {
            if (wbCode.NullOrEmpty())
                return null;

            return ByIdQuery().
                        FirstOrDefault(country => country.TextCode == wbCode);
        }

        protected override IQueryable<Country> ByIdQuery()
            => AllAsQueryable.Include(country => country.Translates);

        private void SetEntityProperties<TDto>(Country entity,
                                               CountryDlDto<TDto> dto)
            where TDto : CountryDlDto<TDto>
            => entity.ShortName = dto.FullName;

        protected override void OnCreate(Country entity,
                                         CreateCountryDlDto dto)
        {
            Validate(null, dto);
            SetEntityProperties(entity, dto);
        }

        protected override void OnUpdate(Country entity,
                                         UpdateCountryDlDto dto)
        {
            Validate(entity, dto);
            SetEntityProperties(entity, dto);
        }

        private void Validate<TDto>(Country entity,
                                    CountryDlDto<TDto> dto)
            where TDto : CountryDlDto<TDto>
        {
            var query = DbSet.AsQueryable();

            string code = dto.Code;
            string textCode = dto.TextCode;

            if (entity != null)
                query = query.Where(a => a.Id != entity.Id);

            if (query.ByNumberCode(code, isIncludePassive: true).Any())
                AddError($"Страна с этим кодом ({code}) уже существует.",
                         nameof(code));

            if (query.ByStringCode(textCode, isIncludePassive: true).Any())
                AddError($"Страна с этим кодом ({textCode}) уже существует.",
                         nameof(textCode));
        }
    }
}
