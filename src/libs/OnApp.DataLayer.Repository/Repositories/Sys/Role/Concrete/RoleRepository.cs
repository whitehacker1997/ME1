using GenericServices;
using Global.EF;
using Microsoft.EntityFrameworkCore;

namespace OnApp.DataLayer.Repository
{
    public class RoleRepository :
        BaseEntityRepository<int, Role, CreateRoleDlDto, UpdateRoleDlDto>,
        IRoleRepository
    {
        public RoleRepository(ICrudServices crudServices)
            : base(crudServices)
        {
        }

        protected override IQueryable<Role> ByIdQuery()
        {
            return AllAsQueryable
                    .Include(a => a.RoleModules)
                    .Include(a => a.Translates);
        }

        protected override void CreateValidate(CreateRoleDlDto dto)
            => Validate(null, dto);
        
        protected override void UpdateValidate(Role entity, UpdateRoleDlDto dto)
            => Validate(entity, dto);
        

        private void Validate<TDto>(Role entity, RoleDlDto<TDto> dto)
            where TDto : RoleDlDto<TDto>
        {
            var query = DbSet.AsQueryable();

            if (entity != null)
                query = query.Where(a => a.Id != entity.Id);
        }

    }
}
