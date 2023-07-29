using AutoMapper;
using OnApp.DataLayer.Repository;
using GenericServices.Configuration;

namespace OnApp.BizLayer.PositionServices
{
    public class PositionTranslateDto :
        PositionTranslateDlDto
    {
        public string LanguageName { get; set; } = null!;
    }
    public class PositionTranslateDtoCOnfig :
        PerDtoConfig<PositionTranslateDto, PositionTranslate>
    {
        public override Action<IMappingExpression<PositionTranslate, PositionTranslateDto>> AlterReadMapping
            => config
                    => config.ForMember(dto => dto.LanguageName,
                                                    dto => dto.MapFrom(entity => entity.Language.FullName));
    }
}
