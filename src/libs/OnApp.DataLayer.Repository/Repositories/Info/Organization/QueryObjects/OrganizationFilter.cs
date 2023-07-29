using Global;

namespace OnApp.DataLayer.Repository
{
    public static class OrganizationFilter
    {
        public static IQueryable<Organization> ByInn(this IQueryable<Organization> source,
                                                      string Inn,
                                                      bool isIncludePassive = false)
        {
            if (Inn.NullOrEmpty())
                throw new ArgumentException($"{nameof(Inn)} cannot be null or empty string", nameof(Inn));

            if (!isIncludePassive)
                source = source.IsActive();

            return source.Where(a => a.Inn.ToLower() == Inn.ToLower());
        }
    }
}
