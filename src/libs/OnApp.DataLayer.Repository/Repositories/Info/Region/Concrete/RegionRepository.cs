using GenericServices;
using Global;
using Global.EF;
using Microsoft.EntityFrameworkCore;

namespace OnApp.DataLayer.Repository
{
    public class RegionRepository :
        BaseEntityRepository<int, Region, CreateRegionDlDto, UpdateRegionDlDto>,
        IRegionRepository

    {
        public RegionRepository(ICrudServices crudServices) :
            base(crudServices)
        {
        }


        public Region ByWbCode(string wbCode)
        {
            if (wbCode.NullOrEmpty())
                return null;

            return ByIdQuery()
                    .FirstOrDefault(region => region.Code == wbCode)!;
        }

        public Region ByRoamingCode(string roamingCode)
        {
            if (roamingCode.NullOrEmpty())
                return null;
            return ByIdQuery()
                    .FirstOrDefault(region => region.RoamingCode == roamingCode)!;
        }

        protected override IQueryable<Region> ByIdQuery()
            => AllAsQueryable.Include(region => region.Translates);

        protected override void CreateValidate(CreateRegionDlDto dto)
            => Validate(null, dto);

        protected override void UpdateValidate(Region entity, UpdateRegionDlDto dto)
            => Validate(entity, dto);

        private void Validate<TDto>(Region entity, RegionDlDto<TDto> dto)
            where TDto : RegionDlDto<TDto>
        {
            var query = DbSet.AsQueryable();

            if (entity != null)
                query = query.Where(region => region.Id != entity.Id);

            if (string.IsNullOrWhiteSpace(dto.Code)
                && query.ByNumberCode(numberCode: dto.Code,
                                      isIncludePassive: true).Any())
                AddError($"Область с этим кодом ({dto.Code}) уже существует.", nameof(dto.Code));
        }
    }
}
