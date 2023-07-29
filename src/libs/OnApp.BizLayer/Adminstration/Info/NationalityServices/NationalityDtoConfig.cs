using AutoMapper;
using OnApp.Core;
using OnApp.DataLayer;
using OnApp.DataLayer.Repository;
using GenericServices.Configuration;

namespace OnApp.BizLayer.NationalityServices
{
    public class NationalityDtoConfig :
        PerDtoConfig<NationalityDto, Nationality>
    {
        public override Action<IMappingExpression<Nationality, NationalityDto>> AlterReadMapping
            => config => config
            .ForMember(dto => dto.StateName,
                        expression => expression.MapFrom(entity => entity.State.Translates.AsQueryable()
                           .FirstOrDefault(StateTranslate.GetExpr(TranslateColumn.full_name, ServiceProvider.CultureHelper.CurrentCulture.Id)).TranslateText ?? 
                                entity.State.FullName));
        }
}
