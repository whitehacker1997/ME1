using Global.Models;

namespace Global
{
    public static class HaveIdFilter
    {
        public static IQueryable<TEntity> FilterByIds<TId, TEntity>(this IQueryable<TEntity> query, IEnumerable<TId> ids)
            where TEntity : IHaveIdProp<TId>
        {
            if (ids != null && ids.Any())
                query = query.Where(a => ids.Contains(a.Id));

            return query;
        }

        public static IQueryable<TEntity> FilterByIds<TId, TEntity>(this IQueryable<TEntity> query, SelectListSortFilterPageOptions<TId> options)
            where TEntity : IHaveIdProp<TId>
        {
            bool haveAnyId = options.Ids != null && options.Ids.Any();

            if (options.IsInitQuery.GetValueOrDefault())
            {
                if (haveAnyId)
                    return query.Where(a => options.Ids.Contains(a.Id));
                return query.Where(a => false);
            }

            if (haveAnyId)
                query = query.Where(a => !options.Ids.Contains(a.Id));

            return query;
        }
    }
}
