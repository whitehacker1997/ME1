using Global.Models;

namespace Global
{
    public static class StateIdFilter
    {
        public static IQueryable<TEntity> IsActive<TEntity>(this IQueryable<TEntity> query)
            where TEntity : IHaveStateId
        {
            if (query == null)
                throw new ArgumentNullException(nameof(query));

            return query.Where(a => a.StateId == StateIdConst.ACTIVE);
        }
        public static IQueryable<TEntity> IsPassive<TEntity>(this IQueryable<TEntity> query)
            where TEntity : IHaveStateId
        {
            if (query == null)
                throw new ArgumentNullException(nameof(query));

            return query.Where(a => a.StateId == StateIdConst.PASSIVE);
        }
    }
}
