using GenericServices.Configuration;
using AutoMapper;
using OnApp.DataLayer.Repository;
using OnApp.DataLayer;
using OnApp.Core;

namespace OnApp.BizLayer.RoleServices
{
    public class RoleDtoConfig :
        PerDtoConfig<RoleDto, Role>
    {
        public override Action<IMappingExpression<Role, RoleDto>> AlterReadMapping =>
            cfg => cfg
                .ForMember(dto => dto.State, ex => ex.MapFrom(ent => ent.State.Translates.AsQueryable()
                    .FirstOrDefault(StateTranslate.GetExpr(TranslateColumn.full_name,ServiceProvider.CultureHelper.CurrentCulture.Id)).TranslateText ?? ent.State.FullName))
                .ForMember(dto => dto.Modules, ex => ex.MapFrom(ent => ent.RoleModules.Select(roleModule => roleModule.ModuleId)));
    }
}
