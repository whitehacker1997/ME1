using AutoMapper;
using GenericServices;
using GenericServices.Configuration;
using Global;

namespace OnApp.DataLayer.Repository
{
    public class CountryTranslateDlDto :
        TranslateDto<CountryTranslateDlDto, CountryTranslate, TranslateColumn>,
        ILinkToEntity<CountryTranslate>
    {
    }

    public class CountryTranslateDlDtoConfig :
        PerDtoConfig<CountryTranslateDlDto, CountryTranslate>
    {
        public override Action<IMappingExpression<CountryTranslate, CountryTranslateDlDto>> AlterReadMapping
            => config 
               => config.ForMember(dto => dto.ColumnName,
                                                    config => config
                                                                .MapFrom(entity 
                                                                            => entity.ColumnName
                                                                                .AsEnum<TranslateColumn>()));

        public override Action<IMappingExpression<CountryTranslateDlDto, CountryTranslate>> AlterSaveMapping
            => config
                => config.ForMember(entity => entity.ColumnName,
                                                 config => config
                                                                .MapFrom(dto => dto.ColumnName));
    }
}
