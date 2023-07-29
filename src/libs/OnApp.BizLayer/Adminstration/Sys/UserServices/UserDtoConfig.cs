using AutoMapper;
using OnApp.Core;
using OnApp.DataLayer;
using OnApp.DataLayer.Repository;
using GenericServices.Configuration;

namespace OnApp.BizLayer.UserServices;

public class UserDtoConfig : 
    PerDtoConfig<UserDto, User>
{
    public override Action<IMappingExpression<User, UserDto>> AlterReadMapping
        => cfg => cfg
            .ForMember(dto => dto.PersonName, ex => ex.MapFrom(ent => ent.Person.FullName))
            .ForMember(dto => dto.StateName,ex => ex.MapFrom(ent => ent.State.Translates.AsQueryable()
                            .FirstOrDefault(StateTranslate.GetExpr(TranslateColumn.full_name,
                                                                    ServiceProvider.CultureHelper.CurrentCulture.Id)).TranslateText ??
                                            ent.State.FullName))   
            .ForMember(dto => dto.OrganizationName,ex => ex.MapFrom(ent => ent.Organization.FullName))
            .ForMember(dto => dto.ParentOrganizationName,ex => ex.MapFrom(ent => ent.Organization.Parent.FullName))
        ;
}
