using Global;

namespace OnApp.DataLayer.Repository
{
    public static class PositionFilter
    {
        public static IQueryable<Position> ByNumberCode(this IQueryable<Position> source,
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
