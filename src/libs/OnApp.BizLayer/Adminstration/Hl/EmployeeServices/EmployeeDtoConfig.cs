using AutoMapper;
using OnApp.Core;
using OnApp.DataLayer;
using OnApp.DataLayer.Repository;
using GenericServices.Configuration;

namespace OnApp.BizLayer.EmployeeServices;

public class EmployeeDtoConfig :
    PerDtoConfig<EmployeeDto, Employee>
{
    public override Action<IMappingExpression<Employee, EmployeeDto>> AlterReadMapping => 
        cfg => cfg
            .ForMember(dto => dto.OrganizationName,ex => ex.MapFrom(ent => ent.Organization.Translates.AsQueryable()
                .FirstOrDefault(OrganizationTranslate.GetExpr(TranslateColumn.full_name,
                                                              ServiceProvider.CultureHelper.CurrentCulture.Id)).TranslateText ??
                                                                           ent.Organization.FullName))
            .ForMember(dto => dto.ParentOrganizationName, ex => ex.MapFrom(ent => ent.ParentOrganization.Translates.AsQueryable()
                .FirstOrDefault(OrganizationTranslate.GetExpr(TranslateColumn.full_name,
                                                              ServiceProvider.CultureHelper.CurrentCulture.Id)).TranslateText ??
                                                                           ent.ParentOrganization.FullName))
            .ForMember(dto => dto.StateName, ex => ex.MapFrom(ent => ent.State.Translates.AsQueryable()
                .FirstOrDefault(StateTranslate.GetExpr(TranslateColumn.full_name,
                                                              ServiceProvider.CultureHelper.CurrentCulture.Id)).TranslateText ??
                                                                           ent.State.FullName))
            .ForMember(dto => dto.PositionName, ex => ex.MapFrom(ent => ent.Position.Translates.AsQueryable()
                .FirstOrDefault(PositionTranslate.GetExpr(TranslateColumn.full_name,
                                                              ServiceProvider.CultureHelper.CurrentCulture.Id)).TranslateText ??
                                                                           ent.Position.FullName))
            ;
}

