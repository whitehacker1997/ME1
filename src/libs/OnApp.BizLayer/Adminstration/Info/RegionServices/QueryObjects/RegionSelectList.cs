using OnApp.Core;
using OnApp.DataLayer;
using OnApp.DataLayer.Repository;
using Global;
using Global.Models;

namespace OnApp.BizLayer.RegionServices
{
    public static class RegionSelectList
    {
        public static SelectList<int> AsSelectList(this IQueryable<Region> region)
            => new SelectList<int>(
                region.IsActive()
                    .Select(region => new SelectListItem<int>
                    {
                        Value = region.Id,
                        OrderCode = region.OrderCode,
                        Text = region.Translates.AsQueryable()
                                                    .FirstOrDefault(RegionTranslate.GetExpr(
                                                        TranslateColumn.full_name,
                                                        ServiceProvider.CultureHelper.CurrentCulture.Id)).TranslateText ??
                                   region.FullName
                    }).OrderBy(country => country.OrderCode)
                            .ThenBy(a => a.Text));
    }
}
