using OnApp.Core;
using OnApp.DataLayer;
using OnApp.DataLayer.Repository;
using Global.Models;

namespace OnApp.BizLayer.EnumServices
{
    public static class StatusSelectList
    {
        public static SelectList<int> AsSelectList(this IQueryable<Status> source)
        {
            return new SelectList<int>(source.Select(status 
                => new SelectListItem<int> {
                    Value = status.Id,
                    Text = status.Translates.
                            AsQueryable()
                                .FirstOrDefault(StatusTranslate.GetExpr(TranslateColumn.full_name,
                                                                        ServiceProvider.CultureHelper.CurrentCulture.Id)).TranslateText ??
                                                                        status.FullName
                }));
        }
    }
}
