using AutoMapper;
using OnApp.Core;
using OnApp.DataLayer;
using OnApp.DataLayer.Repository;
using GenericServices.Configuration;

namespace OnApp.BizLayer.CitizenshipServices
{
    public class CitizenshipDtoConfig :
        PerDtoConfig<CitizenshipDto, Citizenship>
    {
        public override Action<IMappingExpression<Citizenship, CitizenshipDto>> AlterReadMapping
            => config => config
            .ForMember(dto => dto.StateName,
                        expression => expression.MapFrom(entity => entity.State.Translates.AsQueryable()
                           .FirstOrDefault(StateTranslate.GetExpr(TranslateColumn.full_name, ServiceProvider.CultureHelper.CurrentCulture.Id)).TranslateText ?? 
                                entity.State.FullName));
        }
}
