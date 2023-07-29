namespace Global.Models
{
    public class PagedSelectList<TItemValue>
    {
        public PagedSelectList()
        { }

        public PagedSelectList(IPagedResult pagedResult, IEnumerable<SelectListItem<TItemValue>> rows)
            : this(pagedResult.Page, pagedResult.PageSize, pagedResult.Total, rows)
        { }

        public PagedSelectList(int page, int pageSize, long total, IEnumerable<SelectListItem<TItemValue>> rows)
            : this()
        {
            Page = page;
            PageSize = pageSize;
            Total = total;
            Rows = rows;
        }


        public int Page { get; set; }
        public int PageSize { get; set; }
        public long Total { get; set; }
        public IEnumerable<SelectListItem<TItemValue>> Rows { get; set; }
    }

    public class SelectList<TItemValue> : SelectList<TItemValue, SelectListItem<TItemValue>>
    {
        public SelectList()
        {

        }

        public SelectList(IEnumerable<SelectListItem<TItemValue>> collection)
            : base(collection)
        {

        }
    }

    public class SelectList<TItemValue, TItem> : List<TItem>
        where TItem : SelectListItem<TItemValue>
    {
        public SelectList()
        {

        }

        public SelectList(IEnumerable<TItem> collection)
            : base(collection)
        {

        }
    }

    public class SelectListItem<TValue>
    {
        public TValue Value { get; set; }
        public string Text { get; set; }
        public string OrderCode { get; set; }
    }

    public class SelectListItemWithChildren<TValue> : SelectListItem<TValue>
    {
        public List<SelectListItemWithChildren<TValue>> Children { get; set; } = new List<SelectListItemWithChildren<TValue>>();
    }
}
