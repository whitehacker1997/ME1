using AutoMapper;
using OnApp.DataLayer.Repository;
using GenericServices.Configuration;

namespace OnApp.BizLayer.DistrictServices
{
    public class DistrictTranslateDto :
        DistrictTranslateDlDto
    {
        public string LanguageName { get; set; } = null!;
    }
    public class DistrictTranslateDtoCOnfig :
        PerDtoConfig<DistrictTranslateDto, DistrictTranslate>
    {
        public override Action<IMappingExpression<DistrictTranslate, DistrictTranslateDto>> AlterReadMapping
            => config
                    => config.ForMember(dto => dto.LanguageName,
                                                    dto => dto.MapFrom(entity => entity.Language.FullName));
    }
}
