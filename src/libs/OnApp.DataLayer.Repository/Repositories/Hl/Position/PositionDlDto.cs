using Global.EF;
using Global.Attributes;
using AutoMapper;
using OnApp.Core;

namespace OnApp.DataLayer.Repository
{
    public class PositionDlDto<TDto>
        : EntityDto<TDto, Position>
        where TDto : PositionDlDto<TDto>
    {
        public string? Code { get; set; }
        [LocalizedRequired]
        [LocalizedStringLength(250)]
        public string ShortName { get; set; } = null!;
        [LocalizedRequired]
        [LocalizedStringLength(250)]
        public string FullName { get; set; } = null!;

        public List<PositionTranslateDlDto> Translates { get; set; } = new();

        protected override Action<IMappingExpression<TDto, Position>> AlterMapping 
            => config 
                => config.ForMember(entity => entity.Translates,
                                                        expression => expression.Ignore());

        public override Position CreateEntity()
        {
            var entity = base.CreateEntity();

            entity.StateId = StateIdConst.ACTIVE;
            Translates.AddByUniqueFKTo(entity.Translates);

            return entity;
        }

        public override void UpdateEntity(Position entity)
        {
            base.UpdateEntity(entity);
            Translates.ApplyChangesByUniqueFKTo(entity.Translates);
        }
    }
}
