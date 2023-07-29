using AutoMapper;
using OnApp.DataLayer.Repository;
using GenericServices;
using GenericServices.Configuration;

namespace OnApp.BizLayer.CountryServices
{
    public class CountryTranslateDto : 
        CountryTranslateDlDto,
        ILinkToEntity<CountryTranslate>
    {
        public string Language { get; set; } = null!;
    }

    public class CountryTranslateDtoCOnfig :
        PerDtoConfig<CountryTranslateDto, CountryTranslate>
    {
        public override Action<IMappingExpression<CountryTranslate, CountryTranslateDto>> AlterReadMapping
            => config
                    => config.ForMember(dto => dto.Language,
                                                    dto => dto.MapFrom(entity => entity.Language.FullName));
    }
}
