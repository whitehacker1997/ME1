using AutoMapper;
using OnApp.DataLayer.Repository;
using GenericServices.Configuration;

namespace OnApp.BizLayer.NationalityServices
{
    public class NationalityTranslateDto :
        NationalityTranslateDlDto
    {
        public string LanguageName { get; set; } = null!;
    }
    public class NationalityTranslateDtoCOnfig :
        PerDtoConfig<NationalityTranslateDto, NationalityTranslate>
    {
        public override Action<IMappingExpression<NationalityTranslate, NationalityTranslateDto>> AlterReadMapping
            => config
                    => config.ForMember(dto => dto.LanguageName,
                                                    dto => dto.MapFrom(entity => entity.Language.FullName));
    }
}
