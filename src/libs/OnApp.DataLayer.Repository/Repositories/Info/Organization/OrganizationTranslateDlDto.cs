using AutoMapper;
using GenericServices;
using GenericServices.Configuration;
using Global;

namespace OnApp.DataLayer.Repository
{
    public class OrganizationTranslateDlDto :
        TranslateDto<OrganizationTranslateDlDto, OrganizationTranslate, TranslateColumn>,
        ILinkToEntity<OrganizationTranslate>
    {
    }

    public class OrganizationTranslateDlDtoConfig :
        PerDtoConfig<OrganizationTranslateDlDto, OrganizationTranslate>
    {
        public override Action<IMappingExpression<OrganizationTranslate, OrganizationTranslateDlDto>> AlterReadMapping 
            => config 
                => config.ForMember(dto => dto.ColumnName,
                                        config => config.MapFrom(entity 
                                                                    => entity.ColumnName.AsEnum<TranslateColumn>()));

        public override Action<IMappingExpression<OrganizationTranslateDlDto, OrganizationTranslate>> AlterSaveMapping 
            => config 
                => config.ForMember(entity => entity.ColumnName,
                                               config => config.MapFrom(dto => dto.ColumnName));
    }
}
