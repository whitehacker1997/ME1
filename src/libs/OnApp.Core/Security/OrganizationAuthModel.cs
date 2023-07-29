namespace OnApp.Core.Security
{
    public class OrganizationAuthModel
    {
        public int Id { get; set; }
        public string ShortName { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public int? RegionId { get; set; }
        public int? ParentId { get; set; }
        public string Inn { get; set; } = null!;
    }
}
