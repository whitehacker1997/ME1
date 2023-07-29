using AutoMapper;
using GenericServices;
using GenericServices.Configuration;
using Global;

namespace OnApp.DataLayer.Repository
{
    public class RegionTranslateDlDto :
        TranslateDto<RegionTranslateDlDto, RegionTranslate, TranslateColumn>,
        ILinkToEntity<RegionTranslate>
    {
    }

    public class RegionTranslateDlDtoConfig :
        PerDtoConfig<RegionTranslateDlDto, RegionTranslate>
    {
        public override Action<IMappingExpression<RegionTranslate, RegionTranslateDlDto>> AlterReadMapping 
            => config 
                => config.ForMember(dto => dto.ColumnName,
                                        config => config.MapFrom(entity 
                                                                    => entity.ColumnName.AsEnum<TranslateColumn>()));

        public override Action<IMappingExpression<RegionTranslateDlDto, RegionTranslate>> AlterSaveMapping 
            => config 
                => config.ForMember(entity => entity.ColumnName,
                                               config => config.MapFrom(dto => dto.ColumnName));
    }
}
