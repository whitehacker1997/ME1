namespace Global.Models
{
    public class PageOptions : IPageOptions
    {
        public const int DEFAULT_PAGE_SIZE = 20;
        public const int DEFAULT_PAGE_SIZE_LIMIT = 1000;

        private readonly int _defaultPageSize = DEFAULT_PAGE_SIZE;
        private readonly int _pageSizeLimit = DEFAULT_PAGE_SIZE_LIMIT;

        private int _page;
        private int _pageSize;
        public PageOptions(int defaultPageSize, int pageSizeLimit)
        {
            _page = 1;
            _defaultPageSize = defaultPageSize;
            _pageSizeLimit = pageSizeLimit;
        }

        public PageOptions()
            : this(DEFAULT_PAGE_SIZE, DEFAULT_PAGE_SIZE_LIMIT)
        { }

        public virtual int Page
        {
            get => _page;
            set => _page = value > 0 ? value : 1;
        }

        public virtual int PageSize
        {
            get => _pageSize > 0 ? _pageSize : _defaultPageSize;
            set => _pageSize = value > 0 && value <= _pageSizeLimit ? value : _defaultPageSize;
        }


    }
}
