using AutoMapper;
using GenericServices;
using GenericServices.Configuration;
using Global;

namespace OnApp.DataLayer.Repository
{
    public class PositionTranslateDlDto :
        TranslateDto<PositionTranslateDlDto, PositionTranslate, TranslateColumn>,
        ILinkToEntity<PositionTranslate>
    {
    }

    public class PositionTranslateDlDtoConfig :
        PerDtoConfig<PositionTranslateDlDto, PositionTranslate>
    {
        public override Action<IMappingExpression<PositionTranslate, PositionTranslateDlDto>> AlterReadMapping 
            => config 
                => config.ForMember(dto => dto.ColumnName,
                                        config => config.MapFrom(entity 
                                                                    => entity.ColumnName.AsEnum<TranslateColumn>()));

        public override Action<IMappingExpression<PositionTranslateDlDto, PositionTranslate>> AlterSaveMapping 
            => config 
                => config.ForMember(entity => entity.ColumnName,
                                               config => config.MapFrom(dto => dto.ColumnName));
    }
}
