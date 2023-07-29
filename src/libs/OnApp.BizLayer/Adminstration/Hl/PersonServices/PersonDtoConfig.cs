using GenericServices.Configuration;
using AutoMapper;
using OnApp.DataLayer.Repository;
using OnApp.Core;
using OnApp.DataLayer;

namespace OnApp.BizLayer.PersonServices
{
    public class PersonDtoConfig :
        PerDtoConfig<PersonDto, Person>
    {
        public override Action<IMappingExpression<Person, PersonDto>> AlterReadMapping =>
            cfg => cfg
                .ForMember(dto => dto.FullName,ex => ex.MapFrom(ent => ent.FullName))
                .ForMember(dto => dto.StateName, ex => ex.MapFrom(ent => ent.State.Translates.AsQueryable()
                    .FirstOrDefault(StateTranslate.GetExpr(TranslateColumn.full_name, ServiceProvider.CultureHelper.CurrentCulture.Id)).TranslateText ?? ent.State.FullName))
                .ForMember(dto => dto.GenderName, ex => ex.MapFrom(ent => ent.Gender.Translates.AsQueryable()
                    .FirstOrDefault(GenderTranslate.GetExpr(TranslateColumn.full_name, ServiceProvider.CultureHelper.CurrentCulture.Id)).TranslateText ?? ent.Gender.FullName))
                .ForMember(dto => dto.CitizenshipName, ex => ex.MapFrom(ent => ent.Citizenship.Translates.AsQueryable()
                    .FirstOrDefault(CitizenshipTranslate.GetExpr(TranslateColumn.full_name, ServiceProvider.CultureHelper.CurrentCulture.Id)).TranslateText ?? ent.Citizenship.FullName))
                .ForMember(dto => dto.BirthCountry, ex => ex.MapFrom(ent => ent.BirthCountry.Translates.AsQueryable()
                    .FirstOrDefault(CountryTranslate.GetExpr(TranslateColumn.full_name, ServiceProvider.CultureHelper.CurrentCulture.Id)).TranslateText ?? ent.BirthCountry.FullName))
                .ForMember(dto => dto.LivingRegionName, ex => ex.MapFrom(ent => ent.LivingRegion.Translates.AsQueryable()
                    .FirstOrDefault(RegionTranslate.GetExpr(TranslateColumn.full_name, ServiceProvider.CultureHelper.CurrentCulture.Id)).TranslateText ?? ent.LivingRegion.FullName))
                .ForMember(dto => dto.LivingDistrictName, ex => ex.MapFrom(ent => ent.LivingDistrict.Translates.AsQueryable()
                    .FirstOrDefault(DistrictTranslate.GetExpr(TranslateColumn.full_name, ServiceProvider.CultureHelper.CurrentCulture.Id)).TranslateText ?? ent.LivingDistrict.FullName))
                .ForMember(dto => dto.DocumentTypeName,ex => ex.MapFrom(ent => ent.DocumentType.Translates.AsQueryable()
                                    .FirstOrDefault(DocumentTypeTranslate.GetExpr(TranslateColumn.full_name,
                                                                                  ServiceProvider.CultureHelper.CurrentCulture.Id))
                    .TranslateText ?? ent.DocumentType.FullName));
    }
}
