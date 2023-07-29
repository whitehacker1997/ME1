using Global.EF;
using Global.Attributes;
using AutoMapper;
using OnApp.Core;

namespace OnApp.DataLayer.Repository
{
    public class CountryDlDto<TDto> :
        EntityDto<TDto,Country>
        where TDto : CountryDlDto<TDto>
    {
        public string? OrderCode { get; set; }
        [LocalizedRequired]
        [LocalizedStringLength(10)]
        public string Code { get; set; } = null!;
        [LocalizedRequired]
        [LocalizedStringLength(50)]
        public string TextCode { get; set; } = null!;
        public string ShortName { get; set; } = null!;
        [LocalizedRequired]
        [LocalizedStringLength(500)]
        public string FullName { get; set; } = null!;

        public List<CountryTranslateDlDto> Translates { get; set; } = new();

        protected override Action<IMappingExpression<TDto, Country>> AlterMapping 
            => config 
                => config.ForMember(entity => entity.Translates,
                                              expression => expression.Ignore());

        public override Country CreateEntity()
        {
            var entity 
                = base.CreateEntity();

            entity.StateId = StateIdConst.ACTIVE;
            
            Translates.AddByUniqueFKTo(entity.Translates);

            return entity;
        }

        public override void UpdateEntity(Country entity)
        {
            base.UpdateEntity(entity);
            Translates.ApplyChangesByUniqueFKTo(entity.Translates);
        }

    }
}
