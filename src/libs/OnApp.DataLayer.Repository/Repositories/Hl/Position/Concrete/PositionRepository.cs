using GenericServices;
using Global;
using Global.EF;
using Microsoft.EntityFrameworkCore;

namespace OnApp.DataLayer.Repository
{
    public class PositionRepository :
        BaseEntityRepository<int, Position, CreatePositionDlDto, UpdatePositionDlDto>,
        IPositionRepository

    {
        public PositionRepository(ICrudServices crudServices) :
            base(crudServices)
        {
        }


        public Position ByCode(string code)
        {
            if (code.NullOrEmpty())
                return null;

            return ByIdQuery()
                    .FirstOrDefault(citizenship => citizenship.Code == code)!;
        }

        protected override IQueryable<Position> ByIdQuery()
            => AllAsQueryable.Include(citizenship => citizenship.Translates);

        protected override void CreateValidate(CreatePositionDlDto dto)
            => Validate(null, dto);

        protected override void UpdateValidate(Position entity, UpdatePositionDlDto dto)
            => Validate(entity, dto);

        private void Validate<TDto>(Position entity, PositionDlDto<TDto> dto)
            where TDto : PositionDlDto<TDto>
        {
            var query = DbSet.AsQueryable();

            if (entity != null)
                query = query.Where(citizenship => citizenship.Id != entity.Id);

            if (string.IsNullOrWhiteSpace(dto.Code)
                && query.ByNumberCode(numberCode: dto.Code,
                                      isIncludePassive: true).Any())
                AddError($"Позиция с этим кодом ({dto.Code}) уже существует.", nameof(dto.Code));
        }
    }
}
