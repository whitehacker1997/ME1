using Global;

namespace OnApp.DataLayer.Repository
{
    public static class DistrictFilter
    {
        public static IQueryable<District> ByNumberCode(this IQueryable<District> source,
                                                      string numberCode,
                                                      bool isIncludePassive = false)
        {
            if (numberCode.NullOrEmpty())
                throw new ArgumentException($"{nameof(numberCode)} cannot be null or empty string", nameof(numberCode));

            if (!isIncludePassive)
                source = source.IsActive();

            return source.Where(a => a.Code.ToLower() == numberCode.ToLower());
        }
    }
}
