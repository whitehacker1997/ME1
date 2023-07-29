namespace Global.Models
{
    public class SortFilterPageOptions : 
        PageOptions,
        ISortFilterOptions
    {
        public const string ORDER_TYPE_ASC = "ASC";
        public const string ORDER_TYPE_DESC = "DESC";

        public SortFilterPageOptions()
            : base()
            => Init();
        

        public SortFilterPageOptions(int defaultPageSize,
                                     int pageSizeLimit)
            : base(defaultPageSize,
                   pageSizeLimit)
            => Init();

        private void Init()
            => _orderType = ORDER_TYPE_ASC;

        public virtual string? Search { get; set; } = null!;
        public virtual string? SortBy { get; set; } = null!;


        private string _orderType;
        public virtual string OrderType 
        { 
            get => _orderType;
            set => _orderType = (new[] { ORDER_TYPE_ASC, ORDER_TYPE_DESC })
                                .Contains(value.AsString().ToUpper()) ?
                                                                value.ToUpper() :
                                                                ORDER_TYPE_ASC;
        }

        public virtual bool HasSort()
            => !SortBy.NullOrEmpty();

        public virtual bool HasSearch()
            => !Search.NullOrEmpty();
    }
}
