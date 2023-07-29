using Global.Models;

namespace Global
{
    public static class PagedResultQueryObject
    {
        public static PagedResult<TRow> AsPagedResult<TRow>(this IQueryable<TRow> query, IPageOptions options)
        {
            return new PagedResult<TRow>(
                options.Page,
                options.PageSize,
                query.Count(),
                query.Skip(options.PageSize * (options.Page - 1)).Take(options.PageSize).AsEnumerable()
                );
        }

        public static PagedResult<TRow> AsPagedResult<TRow>(this IQueryable<TRow> query, IPageOptions options, Action<TRow, long> rowNumberSetter)
        {
            return new PagedResult<TRow>(
                options.Page,
                options.PageSize,
                query.Count(),
                query.Skip(options.PageSize * (options.Page - 1)).Take(options.PageSize)
                     .AsEnumerable()
                     .Select((a, idx) =>
                     {
                         rowNumberSetter(a, idx + (options.Page - 1) * options.PageSize + 1);
                         return a;
                     })
            );
        }
    }
}
