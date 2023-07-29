using OnApp.Core;
using OnApp.DataLayer;
using OnApp.DataLayer.Repository;
using Global.Models;

namespace OnApp.BizLayer.EnumServices
{
    public static class GenderSelectList
    {
        public static SelectList<int> AsSelectList(this IQueryable<Gender> source)
        {
            return new SelectList<int>(source.Select(gender 
                => new SelectListItem<int> {
                    Value = gender.Id,
                    Text = gender.Translates.
                            AsQueryable()
                                .FirstOrDefault(GenderTranslate.GetExpr(TranslateColumn.full_name,
                                                                        ServiceProvider.CultureHelper.CurrentCulture.Id)).TranslateText ??
                                                                        gender.FullName
                }));
        }
    }
}
