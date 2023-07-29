using OnApp.DataLayer.Repository;
using Global;

namespace OnApp.DataLayer
{
    public static class PersonFilter
    {
        public static IQueryable<Person> ByInn(this IQueryable<Person> source,
                                               string inn,
                                               bool isIncludePassive = false)
        {
            if (inn.NullOrEmpty())
                throw new ArgumentException($"{nameof(inn)} cannot be null or empty string", nameof(inn));

            if (!isIncludePassive)
                source = source.IsActive();

            return source.Where(person => person.Inn.ToLower() == inn.ToLower());
        }

        public static IQueryable<Person> ByPinfl(this IQueryable<Person> source,
                                                 string pinfl,
                                                 bool isIncludePassive = false)
        {
            if (pinfl.NullOrEmpty())
                throw new ArgumentException($"{nameof(pinfl)} cannot be null or empty string", nameof(pinfl));

            if (!isIncludePassive)
                source = source.IsActive();

            return source.Where(person => person.Pinfl.ToLower() == pinfl.ToLower());
        }
    }
}
