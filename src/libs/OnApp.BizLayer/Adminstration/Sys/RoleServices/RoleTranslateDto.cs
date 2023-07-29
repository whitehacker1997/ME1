using AutoMapper;
using OnApp.DataLayer.Repository;
using GenericServices;
using GenericServices.Configuration;

namespace OnApp.BizLayer.RoleServices
{
    public class RoleTranslateDto :
        RoleTranslateDlDto,
        ILinkToEntity<RoleTranslate>
    {
        public string Language { get; set; }
    }

    public class RoleTranslateDtoConfig : 
        PerDtoConfig<RoleTranslateDto, RoleTranslate>
    {
        public override Action<IMappingExpression<RoleTranslate, RoleTranslateDto>> AlterReadMapping =>
            cfg => cfg
                .IncludeBase<RoleTranslate, RoleTranslateDlDto>()
                .ForMember(x => x.Language, x => x.MapFrom(ent => ent.Language.FullName));
    }
}
