namespace Global.Models
{
    public class SelectListSortFilterPageOptions<TId> : SortFilterPageOptions
    {
        public bool? IsInitQuery { get; set; }
        public List<TId> Ids { get; set; } = new List<TId>();

        public override int PageSize 
        { 
            get => (Ids?.Any()).GetValueOrDefault() ? DEFAULT_PAGE_SIZE_LIMIT : base.PageSize; 
            set => base.PageSize = value; 
        }
    }
}
