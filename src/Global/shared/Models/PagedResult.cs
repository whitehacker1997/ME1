namespace Global.Models
{
    public class PagedResult<TRow> : IPagedResult
    {
        public PagedResult()
        {}
        public PagedResult(int page, int pageSize, long total, IEnumerable<TRow> rows)
        {
            Page = page;
            PageSize = pageSize;
            Total = total;
            Rows = rows;
        }
        public PagedResult(IPagedResult pagedResult,IEnumerable<TRow> rows)
            :this(pagedResult.Page,pagedResult.PageSize,pagedResult.Total,rows)
        {}

        public int Page { get; set; }
        public int PageSize { get; set; }
        public long Total { get; set; }
        public IEnumerable<TRow> Rows { get; set; }

        public long GetRowNumber(int rowIndex) => rowIndex + (Page - 1) * PageSize + 1;
        public int GetIntRowNumber(int rowIndex) => rowIndex + (Page - 1) * PageSize + 1;
    }
}
