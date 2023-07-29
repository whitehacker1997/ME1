using AutoMapper;
using OnApp.Core;
using OnApp.DataLayer;
using OnApp.DataLayer.Repository;
using GenericServices.Configuration;

namespace OnApp.BizLayer.CountryServices
{
    public class CountryListDtoConfig :
        PerDtoConfig<CountryListDto, Country>
    {
        public override Action<IMappingExpression<Country, CountryListDto>> AlterReadMapping
             => config
                => config.ForMember(dto => dto.StateName, expression
                                                            => expression.MapFrom(entity => entity.State.Translates
                                                                                                                .AsQueryable()
                                                    .FirstOrDefault(StateTranslate.GetExpr(TranslateColumn.short_name,
                                                                                            ServiceProvider.CultureHelper.CurrentCulture.Id)).TranslateText
                                                                                                ?? entity.State.ShortName));
    }
}
