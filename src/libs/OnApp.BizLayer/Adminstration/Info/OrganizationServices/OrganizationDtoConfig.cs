using AutoMapper;
using OnApp.Core;
using OnApp.DataLayer;
using OnApp.DataLayer.Repository;
using GenericServices.Configuration;

namespace OnApp.BizLayer.OrganizationServices
{
    public class OrganizationDtoConfig :
        PerDtoConfig<OrganizationDto, Organization>
    {
        public override Action<IMappingExpression<Organization, OrganizationDto>> AlterReadMapping
            => config => config
            .ForMember(dto => dto.ParentName,
                        expression => expression.MapFrom(entity => entity.Parent.Translates.AsQueryable()
                            .FirstOrDefault(OrganizationTranslate.GetExpr(TranslateColumn.full_name,
                              ServiceProvider.CultureHelper.CurrentCulture.Id)).TranslateText ??
                                entity.Parent.FullName))
            .ForMember(dto => dto.CountryName,
                        expression => expression.MapFrom(entity => entity.Country.Translates.AsQueryable()
                            .FirstOrDefault(CountryTranslate.GetExpr(TranslateColumn.full_name,
                             ServiceProvider.CultureHelper.CurrentCulture.Id)).TranslateText ??
                                entity.Country.FullName))
            .ForMember(dto => dto.RegionName,
                        expression => expression.MapFrom(entity => entity.Region.Translates.AsQueryable()
                            .FirstOrDefault(RegionTranslate.GetExpr(TranslateColumn.full_name,
                             ServiceProvider.CultureHelper.CurrentCulture.Id)).TranslateText ??
                                entity.Region.FullName))
            .ForMember(dto => dto.DistrictName,
                        expression => expression.MapFrom(entity => entity.District.Translates.AsQueryable()
                            .FirstOrDefault(DistrictTranslate.GetExpr(TranslateColumn.full_name,
                             ServiceProvider.CultureHelper.CurrentCulture.Id)).TranslateText ??
                                entity.District.FullName))
            .ForMember(dto => dto.StateName,
                        expression => expression.MapFrom(entity => entity.State.Translates.AsQueryable()
                           .FirstOrDefault(StateTranslate.GetExpr(TranslateColumn.full_name, ServiceProvider.CultureHelper.CurrentCulture.Id)).TranslateText ?? 
                                entity.State.FullName));
        }
}
