using Global.EF;
using Global.Attributes;
using AutoMapper;
using OnApp.Core;

namespace OnApp.DataLayer.Repository
{
    public class RegionDlDto<TDto>
        : EntityDto<TDto, Region>
        where TDto : RegionDlDto<TDto>
    {
        public string? OrderCode { get; set; }
        public string? Code { get; set; }
        public string? Soato { get; set; }
        public string? RoamingCode { get; set; }
        [LocalizedRequired]
        [LocalizedStringLength(250)]
        public string ShortName { get; set; } = null!;
        [LocalizedRequired]
        [LocalizedStringLength(250)]
        public string FullName { get; set; } = null!;
        [LocalizedRequired]
        [LocalizedRange(1, int.MaxValue)]
        public int CountryId { get; set; }

        public List<RegionTranslateDlDto> Translates { get; set; } = new();

        protected override Action<IMappingExpression<TDto, Region>> AlterMapping 
            => config 
                => config.ForMember(entity => entity.Translates,
                                                        expression => expression.Ignore());

        public override Region CreateEntity()
        {
            var entity = base.CreateEntity();

            entity.StateId = StateIdConst.ACTIVE;
            Translates.AddByUniqueFKTo(entity.Translates);

            return entity;
        }

        public override void UpdateEntity(Region entity)
        {
            base.UpdateEntity(entity);
            Translates.ApplyChangesByUniqueFKTo(entity.Translates);
        }
    }
}
