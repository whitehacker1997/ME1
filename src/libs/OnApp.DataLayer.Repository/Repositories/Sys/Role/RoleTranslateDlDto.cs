using AutoMapper;
using GenericServices;
using GenericServices.Configuration;
using Global;

namespace OnApp.DataLayer.Repository
{
    public class RoleTranslateDlDto :
       TranslateDto<RoleTranslateDlDto, RoleTranslate, TranslateColumn>,
       ILinkToEntity<RoleTranslate>
    {

    }

    public class RoleTranslateDlDtoConfig : PerDtoConfig<RoleTranslateDlDto, RoleTranslate>
    {
        public override Action<IMappingExpression<RoleTranslate, RoleTranslateDlDto>> AlterReadMapping =>
            cfg => cfg
                .ForMember(x => x.ColumnName, x => x.MapFrom(ent => ent.ColumnName.AsEnum<TranslateColumn>()));

        public override Action<IMappingExpression<RoleTranslateDlDto, RoleTranslate>> AlterSaveMapping =>
            cfg => cfg
                .ForMember(x => x.ColumnName, x => x.MapFrom(dto => dto.ColumnName));
    }
}
