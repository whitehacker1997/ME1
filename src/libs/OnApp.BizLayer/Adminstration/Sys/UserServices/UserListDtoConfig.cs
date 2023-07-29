using GenericServices.Configuration;
using AutoMapper;
using OnApp.DataLayer.Repository;
using OnApp.Core;
using OnApp.DataLayer;

namespace OnApp.BizLayer.UserServices;

public class UserListDtoConfig : 
    PerDtoConfig<UserListDto, User>
{
    public override Action<IMappingExpression<User, UserListDto>> AlterReadMapping =>
        cfg => cfg
            .ForMember(dto => dto.StateName, ex => ex.MapFrom(ent => ent.State.Translates.AsQueryable()
                .FirstOrDefault(StateTranslate.GetExpr(TranslateColumn.full_name, ServiceProvider.CultureHelper.CurrentCulture.Id)).TranslateText ?? ent.State.FullName))
            .ForMember(dto => dto.ParentOrganizationName, ex => ex.MapFrom(ent => ent.Organization.Parent.Translates.AsQueryable()
                .FirstOrDefault(OrganizationTranslate.GetExpr(TranslateColumn.full_name, ServiceProvider.CultureHelper.CurrentCulture.Id)).TranslateText ?? ent.Organization.Parent.FullName))
            .ForMember(dto => dto.OrganizationName, ex => ex.MapFrom(ent => ent.Organization.Translates.AsQueryable().FirstOrDefault(OrganizationTranslate.GetExpr(TranslateColumn.full_name, ServiceProvider.CultureHelper.CurrentCulture.Id)).TranslateText ?? ent.Organization.FullName))
            .ForMember(dto => dto.FullName, ex => ex.MapFrom(ent => ent.Person.FullName))
            .ForMember(dto => dto.Roles, ex => ex.MapFrom(ent => ent.UserRoles.Where(userRole => userRole.StateId == StateIdConst.ACTIVE).Select(userRole => userRole.Role.Translates.AsQueryable()
                .FirstOrDefault(RoleTranslate.GetExpr(TranslateColumn.full_name, ServiceProvider.CultureHelper.CurrentCulture.Id)).TranslateText ?? userRole.Role.FullName).ToList()))
            ;
}
