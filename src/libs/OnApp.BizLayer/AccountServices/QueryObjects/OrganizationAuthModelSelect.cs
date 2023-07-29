using OnApp.Core.Security;
using OnApp.DataLayer.Repository;
using OnApp.DataLayer;

namespace OnApp.BizLayer.AccountServices
{
    public static class OrganizationAuthModelSelect
    {
        public static IQueryable<OrganizationAuthModel> MapToAuthModel(this IQueryable<Organization> Organizations)
        {
            return Organizations.Select(a => new OrganizationAuthModel
            {
                Id = a.Id,
                ShortName = a.Translates.AsQueryable().FirstOrDefault(OrganizationTranslate.GetExpr(TranslateColumn.short_name)).TranslateText ?? a.ShortName,
                FullName = a.Translates.AsQueryable().FirstOrDefault(OrganizationTranslate.GetExpr(TranslateColumn.full_name)).TranslateText ?? a.FullName,
                Inn = a.Inn,
                RegionId = a.RegionId,
            });
        }
    }
}
