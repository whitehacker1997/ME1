using AutoMapper;
using OnApp.Core;
using Global.Attributes;
using Global.EF;

namespace OnApp.DataLayer.Repository
{
    public class RoleDlDto<TDto> :
        EntityDto<TDto, Role>
            where TDto : 
                    RoleDlDto<TDto>
    {
        public RoleDlDto()
        {
            Translates = new();
        }

        [LocalizedRequired]
        [LocalizedStringLength(50)]
        public string ShortName { get; set; }
        [LocalizedRequired]
        [LocalizedStringLength(250)]
        public string FullName { get; set; }
        [LocalizedStringLength(50)]
        public string OrderCode { get; set; }
        public bool IsDefault { get; set; }
        public bool IsHr { get; set; }
        public bool IsTopInspector { get; set; }
        public List<int> Modules { get; set; } = new List<int>();
        public List<RoleTranslateDlDto> Translates { get; set; }

        protected override Action<IMappingExpression<TDto, Role>> AlterMapping 
            => cfg => cfg
                        .ForMember(role => role.Translates, ex => ex.Ignore());

        public override Role CreateEntity()
        {
            var entity = base.CreateEntity();

            entity.StateId = StateIdConst.ACTIVE;
            Translates.AddByUniqueFKTo(entity.Translates);
            entity.RoleModules.AddFromForeignKeys(Modules);
            
            return entity;
        }

        public override void UpdateEntity(Role entity)
        {
            entity.RoleModules.UpdateFromForeignKeys(Modules);
            
            base.UpdateEntity(entity);
            
            Translates.ApplyChangesByUniqueFKTo(entity.Translates);
        }

    }
}
