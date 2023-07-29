using OnApp.Core;
using OnApp.DataLayer;
using OnApp.DataLayer.Repository;
using Global;
using Global.Models;

namespace OnApp.BizLayer.DistrictServices
{
    public static class DistrictSelectList
    {
        public static SelectList<int> AsSelectList(this IQueryable<District> District)
            => new SelectList<int>(
                District.IsActive()
                    .Select(District => new SelectListItem<int>
                    {
                        Value = District.Id,
                        OrderCode = District.OrderCode,
                        Text = District.Translates.AsQueryable()
                                                    .FirstOrDefault(DistrictTranslate.GetExpr(
                                                        TranslateColumn.full_name,
                                                        ServiceProvider.CultureHelper.CurrentCulture.Id)).TranslateText ??
                                   District.FullName
                    }).OrderBy(country => country.OrderCode)
                            .ThenBy(a => a.Text));
    }
}
