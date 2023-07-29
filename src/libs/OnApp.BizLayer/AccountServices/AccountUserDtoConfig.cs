using AutoMapper;
using OnApp.Core;
using OnApp.DataLayer;
using OnApp.DataLayer.Repository;
using GenericServices.Configuration;

namespace OnApp.BizLayer.AccountServices
{
    public class AccountUserDtoConfig :
        PerDtoConfig<AccountUserDto, User>
    {
        public override Action<IMappingExpression<User, AccountUserDto>> AlterReadMapping
            => config
                => config
                    .ForMember(dto => dto.ShortName, ex => ex.MapFrom(ent => ent.Person.FirstName))
                    .ForMember(dto => dto.FullName, ex => ex.MapFrom(ent => $"{ent.Person.LastName} {ent.Person.FirstName} {ent.Person.MiddleName}"))
                    .ForMember(dto => dto.Inn, ex => ex.MapFrom(ent => ent.Person.Inn))
                    .ForMember(dto => dto.Pinfl, ex => ex.MapFrom(ent => ent.Person.Pinfl))
                    .ForMember(dto => dto.OrganizationName, ex => ex.MapFrom(ent => ent.Organization.Translates.AsQueryable().
                        FirstOrDefault(OrganizationTranslate.GetExpr(TranslateColumn.full_name,
                                                                     ServiceProvider.CultureHelper.CurrentCulture.Id))
                            .TranslateText ?? ent.Organization.FullName))
                    .ForMember(dto => dto.StateName, ex => ex.MapFrom(ent => ent.State.Translates.AsQueryable().
                        FirstOrDefault(StateTranslate.GetExpr(TranslateColumn.full_name,
                                                                     ServiceProvider.CultureHelper.CurrentCulture.Id))
                            .TranslateText ?? ent.State.FullName))
                    .ForMember(dto => dto.LanguageName, ex => ex.MapFrom(ent => ent.Language.FullName))
                    .ForMember(dto => dto.Modules, ex => ex.MapFrom(ent => ent.UserRoles.Where(userRole => userRole.StateId ==
                                    StateIdConst.ACTIVE).SelectMany(userRole => userRole.Role.RoleModules.Select(roleModule => roleModule.Module.Code)).Distinct()))
                    .ForMember(dto => dto.Roles, ex => ex.MapFrom(ent => ent.UserRoles.Where(userRole => userRole.StateId == StateIdConst.ACTIVE).Select(userRole => userRole.Role.Translates.AsQueryable()
                            .FirstOrDefault(RoleTranslate.GetExpr(TranslateColumn.full_name, ServiceProvider.CultureHelper.CurrentCulture.Id)).TranslateText ?? userRole.Role.FullName).ToList()));

    }
}
