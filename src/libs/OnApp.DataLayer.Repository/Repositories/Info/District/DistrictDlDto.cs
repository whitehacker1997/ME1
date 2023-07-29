using Global.EF;
using Global.Attributes;
using AutoMapper;
using OnApp.Core;

namespace OnApp.DataLayer.Repository
{
    public class DistrictDlDto<TDto>
        : EntityDto<TDto, District>
        where TDto : DistrictDlDto<TDto>
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
        public int RegionId { get; set; }

        public List<DistrictTranslateDlDto> Translates { get; set; } = new();

        protected override Action<IMappingExpression<TDto, District>> AlterMapping 
            => config 
                => config.ForMember(entity => entity.Translates,
                                                        expression => expression.Ignore());

        public override District CreateEntity()
        {
            var entity = base.CreateEntity();

            entity.StateId = StateIdConst.ACTIVE;
            Translates.AddByUniqueFKTo(entity.Translates);

            return entity;
        }

        public override void UpdateEntity(District entity)
        {
            base.UpdateEntity(entity);
            Translates.ApplyChangesByUniqueFKTo(entity.Translates);
        }
    }
}
