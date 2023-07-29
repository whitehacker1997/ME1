using AutoMapper;
using GenericServices;
using GenericServices.Configuration;
using Global;

namespace OnApp.DataLayer.Repository
{
    public class NationalityTranslateDlDto :
        TranslateDto<NationalityTranslateDlDto, NationalityTranslate, TranslateColumn>,
        ILinkToEntity<NationalityTranslate>
    {
    }

    public class NationalityTranslateDlDtoConfig :
        PerDtoConfig<NationalityTranslateDlDto, NationalityTranslate>
    {
        public override Action<IMappingExpression<NationalityTranslate, NationalityTranslateDlDto>> AlterReadMapping 
            => config 
                => config.ForMember(dto => dto.ColumnName,
                                        config => config.MapFrom(entity 
                                                                    => entity.ColumnName.AsEnum<TranslateColumn>()));

        public override Action<IMappingExpression<NationalityTranslateDlDto, NationalityTranslate>> AlterSaveMapping 
            => config 
                => config.ForMember(entity => entity.ColumnName,
                                               config => config.MapFrom(dto => dto.ColumnName));
    }
}
