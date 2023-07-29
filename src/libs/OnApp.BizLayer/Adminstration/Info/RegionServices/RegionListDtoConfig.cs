using AutoMapper;
using OnApp.Core;
using OnApp.DataLayer;
using OnApp.DataLayer.Repository;
using GenericServices.Configuration;

namespace OnApp.BizLayer.RegionServices
{
    public class RegionListDtoConfig :
        PerDtoConfig<RegionListDto, Region>
    {
        public override Action<IMappingExpression<Region, RegionListDto>> AlterReadMapping
            => config => config
            .ForMember(dto => dto.StateName,
                        expression => expression.MapFrom(entity => entity.State.Translates.AsQueryable()
                           .FirstOrDefault(StateTranslate.GetExpr(TranslateColumn.full_name, ServiceProvider.CultureHelper.CurrentCulture.Id)).TranslateText ?? 
                                entity.State.FullName))
            .ForMember(dto => dto.CountryName,
                        expression => expression
                        .MapFrom(entity => entity.Country.Translates.AsQueryable().
                            FirstOrDefault(CountryTranslate.GetExpr(TranslateColumn.full_name,ServiceProvider.CultureHelper.CurrentCulture.Id)).TranslateText ??
                                 entity.Country.FullName));
        }
}
