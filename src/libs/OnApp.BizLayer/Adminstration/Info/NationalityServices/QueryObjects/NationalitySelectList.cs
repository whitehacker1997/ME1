using OnApp.Core;
using OnApp.DataLayer;
using OnApp.DataLayer.Repository;
using Global;
using Global.Models;

namespace OnApp.BizLayer.NationalityServices
{
    public static class NationalitySelectList
    {
        public static SelectList<int> AsSelectList(this IQueryable<Nationality> nationality)
            => new SelectList<int>(
                nationality.IsActive()
                    .Select(nationality => new SelectListItem<int>
                    {
                        Value = nationality.Id,
                        OrderCode = nationality.WbCode,
                        Text = nationality.Translates.AsQueryable()
                                                    .FirstOrDefault(NationalityTranslate.GetExpr(
                                                        TranslateColumn.full_name,
                                                        ServiceProvider.CultureHelper.CurrentCulture.Id)).TranslateText ??
                                   nationality.FullName
                    }).OrderBy(country => country.OrderCode)
                            .ThenBy(a => a.Text));
    }
}
