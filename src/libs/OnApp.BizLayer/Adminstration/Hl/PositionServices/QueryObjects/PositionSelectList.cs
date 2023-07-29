using OnApp.Core;
using OnApp.DataLayer;
using OnApp.DataLayer.Repository;
using Global;
using Global.Models;

namespace OnApp.BizLayer.PositionServices
{
    public static class PositionSelectList
    {
        public static SelectList<int> AsSelectList(this IQueryable<Position> position)
            => new SelectList<int>(
                position.IsActive()
                    .Select(position => new PositionSelectListDto<int>
                    {
                        Value = position.Id,
                        OrderCode = position.Code,
                        Text = position.Translates.AsQueryable()
                                                    .FirstOrDefault(PositionTranslate.GetExpr(
                                                        TranslateColumn.full_name,
                                                        ServiceProvider.CultureHelper.CurrentCulture.Id)).TranslateText ??
                                   position.FullName,
                        IsDoctor = position.IsDoctor
                    }).OrderBy(country => country.OrderCode)
                            .ThenBy(a => a.Text));
    }

    public class PositionSelectListDto<T> : SelectListItem<T>
    {
        public bool IsDoctor { get; set; }
    }
}
