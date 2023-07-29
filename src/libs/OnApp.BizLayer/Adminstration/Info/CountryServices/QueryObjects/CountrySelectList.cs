using OnApp.Core;
using OnApp.DataLayer;
using OnApp.DataLayer.Repository;
using Global;
using Global.Models;

namespace OnApp.BizLayer
{
    public static class CountrySelectList
    {
        public static SelectList<int> AsSelectList(this IQueryable<Country> country)
            => new SelectList<int>(
                country
                    .IsActive()
                        .Select(country => new SelectListItem<int>
                        { 
                            Value = country.Id,
                            OrderCode = country.OrderCode,
                            Text = country.Translates
                                                .AsQueryable()
                                                    .FirstOrDefault(CountryTranslate.GetExpr(TranslateColumn.full_name,
                                                                                             ServiceProvider.CultureHelper.CurrentCulture.Id)).TranslateText ??
                                   country.FullName
                        }).OrderBy(country => country.OrderCode)
                            .ThenBy(a => a.Text));
    }
}
