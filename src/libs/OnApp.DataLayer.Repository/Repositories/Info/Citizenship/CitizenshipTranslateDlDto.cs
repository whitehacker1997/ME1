using AutoMapper;
using GenericServices;
using GenericServices.Configuration;
using Global;

namespace OnApp.DataLayer.Repository
{
    public class CitizenshipTranslateDlDto :
        TranslateDto<CitizenshipTranslateDlDto, CitizenshipTranslate, TranslateColumn>,
        ILinkToEntity<CitizenshipTranslate>
    {
    }

    public class CitizenshipTranslateDlDtoConfig :
        PerDtoConfig<CitizenshipTranslateDlDto, CitizenshipTranslate>
    {
        public override Action<IMappingExpression<CitizenshipTranslate, CitizenshipTranslateDlDto>> AlterReadMapping 
            => config 
                => config.ForMember(dto => dto.ColumnName,
                                        config => config.MapFrom(entity 
                                                                    => entity.ColumnName.AsEnum<TranslateColumn>()));

        public override Action<IMappingExpression<CitizenshipTranslateDlDto, CitizenshipTranslate>> AlterSaveMapping 
            => config 
                => config.ForMember(entity => entity.ColumnName,
                                               config => config.MapFrom(dto => dto.ColumnName));
    }
}
