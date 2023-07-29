using Global;

namespace OnApp.DataLayer.Repository
{
    public static class NationalityFilter
    {
        public static IQueryable<Nationality> ByNumberCode(this IQueryable<Nationality> source,
                                                      string numberCode,
                                                      bool isIncludePassive = false)
        {
            if (numberCode.NullOrEmpty())
                throw new ArgumentException($"{nameof(numberCode)} cannot be null or empty string", nameof(numberCode));

            if (!isIncludePassive)
                source = source.IsActive();

            return source.Where(a => a.WbCode.ToLower() == numberCode.ToLower());
        }
    }
}
