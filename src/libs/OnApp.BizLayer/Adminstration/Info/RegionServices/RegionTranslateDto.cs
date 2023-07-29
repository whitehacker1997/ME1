using AutoMapper;
using OnApp.DataLayer.Repository;
using GenericServices.Configuration;

namespace OnApp.BizLayer.RegionServices
{
    public class RegionTranslateDto :
        RegionTranslateDlDto
    {
        public string LanguageName { get; set; } = null!;
    }
    public class RegionTranslateDtoCOnfig :
        PerDtoConfig<RegionTranslateDto, RegionTranslate>
    {
        public override Action<IMappingExpression<RegionTranslate, RegionTranslateDto>> AlterReadMapping
            => config
                    => config.ForMember(dto => dto.LanguageName,
                                                    dto => dto.MapFrom(entity => entity.Language.FullName));
    }
}
