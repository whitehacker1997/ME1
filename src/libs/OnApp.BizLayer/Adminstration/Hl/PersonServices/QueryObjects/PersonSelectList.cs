using OnApp.DataLayer.Repository;
using Global;
using Global.Models;

namespace OnApp.BizLayer
{
    public static class PersonSelectList
    {
        public static SelectList<int> AsSelectList(this IQueryable<Person> query)
        {
            return new SelectList<int>(
                query
                    .IsActive()
                    .Select(person => new SelectListItem<int>
                    {
                        Value = person.Id,
                        OrderCode = person.Pinfl,
                        Text = person.FullName
                    })
                    .OrderBy(person => person.OrderCode)
                    .ThenBy(person => person.Text)
                );
        }
    }
}
