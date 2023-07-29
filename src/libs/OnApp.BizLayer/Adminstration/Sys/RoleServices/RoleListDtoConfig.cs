using GenericServices.Configuration;
using AutoMapper;
using OnApp.DataLayer.Repository;
using OnApp.DataLayer;
using OnApp.Core;

namespace OnApp.BizLayer.RoleServices
{
    public class RoleListDtoConfig : 
        PerDtoConfig<RoleListDto, Role>
    {
        public override Action<IMappingExpression<Role, RoleListDto>> AlterReadMapping =>
            cfg => cfg
                .ForMember(dto => dto.ShortName, ex => ex.MapFrom(ent => ent.Translates.AsQueryable()
                    .FirstOrDefault(RoleTranslate.GetExpr(TranslateColumn.short_name, ServiceProvider.CultureHelper.CurrentCulture.Id)).TranslateText ?? ent.ShortName))
                .ForMember(dto => dto.FullName, ex => ex.MapFrom(ent => ent.Translates.AsQueryable()
                    .FirstOrDefault(RoleTranslate.GetExpr(TranslateColumn.full_name, ServiceProvider.CultureHelper.CurrentCulture.Id)).TranslateText ?? ent.FullName))
                .ForMember(dto => dto.State, ex => ex.MapFrom(ent => ent.State.Translates.AsQueryable()
                    .FirstOrDefault(StateTranslate.GetExpr(TranslateColumn.full_name, ServiceProvider.CultureHelper.CurrentCulture.Id)).TranslateText ?? ent.State.FullName));
    }
}
