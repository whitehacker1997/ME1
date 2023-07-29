using Global.EF;
using AutoMapper;
using OnApp.Core;
using Global.Attributes;

namespace OnApp.DataLayer.Repository
{
    public class OrganizationDlDto<TDto>
        : EntityDto<TDto, Organization>
        where TDto : OrganizationDlDto<TDto>
    {
        public string? OrderCode { get; set; }
        [LocalizedRequired]
        public string FullName { get; set; } = null!;
        public string? Inn { get; set; }
        public int? ParentId { get; set; }
        [LocalizedRequired]
        public int CountryId { get; set; }
        [LocalizedRequired]
        public int RegionId { get; set; }
        public int? DistrictId { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Director { get; set; }
        public string? Latitude { get; set; }
        public string? Longitude { get; set; }

        public List<OrganizationTranslateDlDto> Translates { get; set; } = new();

        protected override Action<IMappingExpression<TDto, Organization>> AlterMapping 
            => config 
                => config.ForMember(entity => entity.Translates,
                                                        expression => expression.Ignore());

        public override Organization CreateEntity()
        {
            var entity = base.CreateEntity();

            entity.StateId = StateIdConst.ACTIVE;
            Translates.AddByUniqueFKTo(entity.Translates);

            return entity;
        }

        public override void UpdateEntity(Organization entity)
        {
            base.UpdateEntity(entity);
            Translates.ApplyChangesByUniqueFKTo(entity.Translates);
        }
    }
}
