using Global.EF;
using Global.Attributes;
using AutoMapper;
using OnApp.Core;

namespace OnApp.DataLayer.Repository
{
    public class NationalityDlDto<TDto>
        : EntityDto<TDto, Nationality>
        where TDto : NationalityDlDto<TDto>
    {
        public string? WbCode { get; set; }
        [LocalizedRequired]
        [LocalizedStringLength(250)]
        public string ShortName { get; set; } = null!;
        [LocalizedRequired]
        [LocalizedStringLength(250)]
        public string FullName { get; set; } = null!;

        public List<NationalityTranslateDlDto> Translates { get; set; } = new();

        protected override Action<IMappingExpression<TDto, Nationality>> AlterMapping 
            => config 
                => config.ForMember(entity => entity.Translates,
                                                        expression => expression.Ignore());

        public override Nationality CreateEntity()
        {
            var entity = base.CreateEntity();

            entity.StateId = StateIdConst.ACTIVE;
            Translates.AddByUniqueFKTo(entity.Translates);

            return entity;
        }

        public override void UpdateEntity(Nationality entity)
        {
            base.UpdateEntity(entity);
            Translates.ApplyChangesByUniqueFKTo(entity.Translates);
        }
    }
}
