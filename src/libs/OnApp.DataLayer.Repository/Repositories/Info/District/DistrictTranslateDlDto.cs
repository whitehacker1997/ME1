using AutoMapper;
using GenericServices;
using GenericServices.Configuration;
using Global;

namespace OnApp.DataLayer.Repository
{
    public class DistrictTranslateDlDto :
        TranslateDto<DistrictTranslateDlDto, DistrictTranslate, TranslateColumn>,
        ILinkToEntity<DistrictTranslate>
    {
    }

    public class DistrictTranslateDlDtoConfig :
        PerDtoConfig<DistrictTranslateDlDto, DistrictTranslate>
    {
        public override Action<IMappingExpression<DistrictTranslate, DistrictTranslateDlDto>> AlterReadMapping 
            => config 
                => config.ForMember(dto => dto.ColumnName,
                                        config => config.MapFrom(entity 
                                                                    => entity.ColumnName.AsEnum<TranslateColumn>()));

        public override Action<IMappingExpression<DistrictTranslateDlDto, DistrictTranslate>> AlterSaveMapping 
            => config 
                => config.ForMember(entity => entity.ColumnName,
                                               config => config.MapFrom(dto => dto.ColumnName));
    }
}
