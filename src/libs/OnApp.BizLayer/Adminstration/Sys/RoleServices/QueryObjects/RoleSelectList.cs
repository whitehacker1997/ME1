using OnApp.Core;
using OnApp.DataLayer;
using OnApp.DataLayer.Repository;
using Global;
using Global.Models;
using System.Data;

namespace OnApp.BizLayer
{
    public static class RoleSelectList
    {
        public static SelectList<int> AsSelectList(this IQueryable<Role> query)
        {
            return new SelectList<int>(
                query
                    .IsActive()              
                    .Select(role => new SelectListItem<int>
                    {
                        Value = role.Id,
                        OrderCode = role.OrderCode,
                        Text = role.Translates.AsQueryable().FirstOrDefault(RoleTranslate.GetExpr(TranslateColumn.full_name, ServiceProvider.CultureHelper.CurrentCulture.Id)).TranslateText ?? role.FullName
                    })
                    .OrderBy(role => role.OrderCode)
                    .ThenBy(role => role.Text)
                );
        }
    }
}
