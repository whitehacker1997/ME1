using OnApp.Core;
using OnApp.DataLayer;
using OnApp.DataLayer.Repository;
using Global;
using Global.Models;

namespace OnApp.BizLayer.CitizenshipServices
{
    public static class CitizenshipSelectList
    {
        public static SelectList<int> AsSelectList(this IQueryable<Citizenship> citizenship)
            => new SelectList<int>(
                citizenship.IsActive()
                    .Select(citizenship => new SelectListItem<int>
                    {
                        Value = citizenship.Id,
                        OrderCode = citizenship.WbCode,
                        Text = citizenship.Translates.AsQueryable()
                                                    .FirstOrDefault(CitizenshipTranslate.GetExpr(
                                                        TranslateColumn.full_name,
                                                        ServiceProvider.CultureHelper.CurrentCulture.Id)).TranslateText ??
                                   citizenship.FullName
                    }).OrderBy(country => country.OrderCode)
                            .ThenBy(a => a.Text));
    }
}
