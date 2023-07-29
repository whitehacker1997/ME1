using AutoMapper;
using OnApp.DataLayer.Repository;
using GenericServices.Configuration;

namespace OnApp.BizLayer.CitizenshipServices
{
    public class CitizenshipTranslateDto :
        CitizenshipTranslateDlDto
    {
        public string LanguageName { get; set; } = null!;
    }
    public class CitizenshipTranslateDtoCOnfig :
        PerDtoConfig<CitizenshipTranslateDto, CitizenshipTranslate>
    {
        public override Action<IMappingExpression<CitizenshipTranslate, CitizenshipTranslateDto>> AlterReadMapping
            => config
                    => config.ForMember(dto => dto.LanguageName,
                                                    dto => dto.MapFrom(entity => entity.Language.FullName));
    }
}
