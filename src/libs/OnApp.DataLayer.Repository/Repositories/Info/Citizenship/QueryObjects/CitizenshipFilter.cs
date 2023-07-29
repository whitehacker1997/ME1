using Global;

namespace OnApp.DataLayer.Repository
{
    public static class CitizenshipFilter
    {
        public static IQueryable<Citizenship> ByNumberCode(this IQueryable<Citizenship> source,
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
