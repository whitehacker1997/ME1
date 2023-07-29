using OnApp.Core;
using OnApp.DataLayer;
using OnApp.DataLayer.Repository;
using Global;
using Global.Models;

namespace OnApp.BizLayer.OrganizationServices
{
    public static class OrganizationSelectList
    {
        public static SelectList<int> AsSelectList(this IQueryable<Organization> organization)
            => new SelectList<int>(
                organization.IsActive()
                    .Select(organization => new SelectListItem<int>
                    {
                        Value = organization.Id,
                        OrderCode = organization.OrderCode,
                        Text = organization.Translates.AsQueryable()
                                                    .FirstOrDefault(OrganizationTranslate.GetExpr(
                                                        TranslateColumn.full_name,
                                                        ServiceProvider.CultureHelper.CurrentCulture.Id)).TranslateText ??
                                   organization.FullName
                    }).OrderBy(country => country.OrderCode)
                            .ThenBy(a => a.Text));
    }
}
