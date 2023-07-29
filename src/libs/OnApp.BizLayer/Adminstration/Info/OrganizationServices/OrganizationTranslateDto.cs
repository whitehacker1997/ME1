using AutoMapper;
using OnApp.DataLayer.Repository;
using GenericServices.Configuration;

namespace OnApp.BizLayer.OrganizationServices
{
    public class OrganizationTranslateDto :
        OrganizationTranslateDlDto
    {
        public string LanguageName { get; set; } = null!;
    }
    public class OrganizationTranslateDtoCOnfig :
        PerDtoConfig<OrganizationTranslateDto, OrganizationTranslate>
    {
        public override Action<IMappingExpression<OrganizationTranslate, OrganizationTranslateDto>> AlterReadMapping
            => config
                    => config.ForMember(dto => dto.LanguageName,
                                                    dto => dto.MapFrom(entity => entity.Language.FullName));
    }
}
