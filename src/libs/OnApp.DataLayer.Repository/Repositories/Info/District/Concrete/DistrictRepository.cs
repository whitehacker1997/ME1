using GenericServices;
using Global;
using Global.EF;
using Microsoft.EntityFrameworkCore;

namespace OnApp.DataLayer.Repository
{
    public class DistrictRepository :
        BaseEntityRepository<int, District, CreateDistrictDlDto, UpdateDistrictDlDto>,
        IDistrictRepository

    {
        public DistrictRepository(ICrudServices crudServices) :
            base(crudServices)
        {
        }


        public District ByWbCode(string wbCode)
        {
            if (wbCode.NullOrEmpty())
                return null;

            return ByIdQuery()
                    .FirstOrDefault(District => District.Code == wbCode)!;
        }

        public District ByRoamingCode(string roamingCode)
        {
            if (roamingCode.NullOrEmpty())
                return null;
            return ByIdQuery()
                    .FirstOrDefault(District => District.RoamingCode == roamingCode)!;
        }

        protected override IQueryable<District> ByIdQuery()
            => AllAsQueryable.Include(District => District.Translates);

        protected override void CreateValidate(CreateDistrictDlDto dto)
            => Validate(null, dto);

        protected override void UpdateValidate(District entity, UpdateDistrictDlDto dto)
            => Validate(entity, dto);

        private void Validate<TDto>(District entity, DistrictDlDto<TDto> dto)
            where TDto : DistrictDlDto<TDto>
        {
            var query = DbSet.AsQueryable();

            if (entity != null)
                query = query.Where(District => District.Id != entity.Id);

            if (string.IsNullOrWhiteSpace(dto.Code)
                && query.ByNumberCode(numberCode: dto.Code,
                                      isIncludePassive: true).Any())
                AddError($"Округ с этим кодом ({dto.Code}) уже существует.", nameof(dto.Code));
        }
    }
}
