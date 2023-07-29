using AutoMapper;
using OnApp.Core;
using OnApp.DataLayer;
using OnApp.DataLayer.Repository;
using GenericServices.Configuration;

namespace OnApp.BizLayer.DistrictServices
{
    public class DistrictDtoConfig :
        PerDtoConfig<DistrictDto, District>
    {
        public override Action<IMappingExpression<District, DistrictDto>> AlterReadMapping
            => config => config
            .ForMember(dto => dto.StateName,
                        expression => expression.MapFrom(entity => entity.State.Translates.AsQueryable()
                           .FirstOrDefault(StateTranslate.GetExpr(TranslateColumn.full_name, ServiceProvider.CultureHelper.CurrentCulture.Id)).TranslateText ?? 
                                entity.State.FullName))
            .ForMember(dto => dto.RegionName,
                        expression => expression
                        .MapFrom(entity => entity.Region.Translates.AsQueryable().
                            FirstOrDefault(RegionTranslate.GetExpr(TranslateColumn.full_name,ServiceProvider.CultureHelper.CurrentCulture.Id)).TranslateText ??
                                 entity.Region.FullName));
        }
}
