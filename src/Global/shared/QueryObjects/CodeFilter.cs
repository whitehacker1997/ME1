using Global.Models;

namespace Global
{
    public static class CodeFilter
    {
        public static IQueryable<TEntity> ByCode<TEntity>(this IQueryable<TEntity> query, string code)
            where TEntity : IHaveCode
        {
            if (query == null)
                throw new ArgumentNullException(nameof(query));
            if (code.NullOrEmpty())
                throw new ArgumentException($"{nameof(code)} cannot be null or empty string", nameof(code));

            return query.Where(a => a.Code.ToLower() == code.ToLower());
        }

        public static IQueryable<TEntity> ByCode<TEntity>(this IQueryable<TEntity> query, string code, bool onlyActive)
            where TEntity : IHaveCode, IHaveStateId
        {
            if (query == null)
                throw new ArgumentNullException(nameof(query));
            if (code.NullOrEmpty())
                throw new ArgumentException($"{nameof(code)} cannot be null or empty string", nameof(code));

            if (onlyActive)
                query = query.Where(a => a.StateId == StateIdConst.ACTIVE);

            return query.Where(a => a.Code.ToLower() == code.ToLower());
        }

    }
}
