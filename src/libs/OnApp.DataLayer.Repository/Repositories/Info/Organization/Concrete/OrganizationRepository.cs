using GenericServices;
using Global;
using Global.EF;
using Microsoft.EntityFrameworkCore;

namespace OnApp.DataLayer.Repository
{
    public class OrganizationRepository :
        BaseEntityRepository<int, Organization, CreateOrganizationDlDto, UpdateOrganizationDlDto>,
        IOrganizationRepository

    {
        public OrganizationRepository(ICrudServices crudServices) :
            base(crudServices)
        {
        }

        private void SetEntityProperties<TDto>(Organization entity,
                                               OrganizationDlDto<TDto> dto)
            where TDto : OrganizationDlDto<TDto>
            => entity.ShortName = dto.FullName;

        protected override void OnCreate(Organization entity, CreateOrganizationDlDto dto)
            => SetEntityProperties(entity, dto);

        protected override void OnUpdate(Organization entity, UpdateOrganizationDlDto dto)
            => SetEntityProperties(entity, dto);

        public Organization ByInn(string inn)
        {
            if (inn.NullOrEmpty())
                return null;

            return ByIdQuery()
                    .FirstOrDefault(organization => organization.Inn == inn)!;
        }

        protected override IQueryable<Organization> ByIdQuery()
            => AllAsQueryable.Include(organization => organization.Translates);

        protected override void CreateValidate(CreateOrganizationDlDto dto)
            => Validate(null, dto);

        protected override void UpdateValidate(Organization entity, UpdateOrganizationDlDto dto)
            => Validate(entity, dto);

        private void Validate<TDto>(Organization entity, OrganizationDlDto<TDto> dto)
            where TDto : OrganizationDlDto<TDto>
        {
            var query = DbSet.AsQueryable();

            if (entity != null)
                query = query.Where(organization => organization.Id != entity.Id);

            if (string.IsNullOrWhiteSpace(dto.Inn)
                && query.ByInn(Inn: dto.Inn,
                                      isIncludePassive: true).Any())
                AddError($"Организация с этим инн ({dto.Inn}) уже существует.", nameof(dto.Inn));
        }
    }
}
