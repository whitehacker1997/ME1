using OnApp.Core;
using OnApp.DataLayer;
using OnApp.DataLayer.Repository;
using Global.Models;

namespace OnApp.BizLayer.EnumServices
{
    public static class StateSelectList
    {
        public static SelectList<int> AsSelectList(this IQueryable<State> source)
        {
            return new SelectList<int>(source.Select(state 
                => new SelectListItem<int> {
                    Value = state.Id,
                    Text = state.Translates.
                            AsQueryable()
                                .FirstOrDefault(StateTranslate.GetExpr(TranslateColumn.full_name,
                                                                        ServiceProvider.CultureHelper.CurrentCulture.Id)).TranslateText ??
                                                                        state.FullName
                }));
        }
    }
}
