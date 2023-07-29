using AutoMapper;
using OnApp.DataLayer;
using OnApp.DataLayer.Repository;
using GenericServices.Configuration;

namespace OnApp.BizLayer.CountryServices
{
    public class CountryDtoConfig :
        PerDtoConfig<CountryDto, Country>
    {
        public override Action<IMappingExpression<Country, CountryDto>> AlterReadMapping
            => config
                => config.ForMember(dto => dto.StateName,
                                            expression => expression.MapFrom(entity
                                                                                => entity.State.Translates
                                                                                    .AsQueryable()
                                                                                    .FirstOrDefault(StateTranslate.GetExpr(TranslateColumn.full_name)).TranslateText ??
                                                                                        entity.State.FullName));
    }
}
