using Global.EF;
using Global.Attributes;
using AutoMapper;
using OnApp.Core;

namespace OnApp.DataLayer.Repository
{
    public class CitizenshipDlDto<TDto>
        : EntityDto<TDto, Citizenship>
        where TDto : CitizenshipDlDto<TDto>
    {
        public string? WbCode { get; set; }
        [LocalizedRequired]
        [LocalizedStringLength(250)]
        public string ShortName { get; set; } = null!;
        [LocalizedRequired]
        [LocalizedStringLength(250)]
        public string FullName { get; set; } = null!;

        public List<CitizenshipTranslateDlDto> Translates { get; set; } = new();

        protected override Action<IMappingExpression<TDto, Citizenship>> AlterMapping 
            => config 
                => config.ForMember(entity => entity.Translates,
                                                        expression => expression.Ignore());

        public override Citizenship CreateEntity()
        {
            var entity = base.CreateEntity();

            entity.StateId = StateIdConst.ACTIVE;
            Translates.AddByUniqueFKTo(entity.Translates);

            return entity;
        }

        public override void UpdateEntity(Citizenship entity)
        {
            base.UpdateEntity(entity);
            Translates.ApplyChangesByUniqueFKTo(entity.Translates);
        }
    }
}
