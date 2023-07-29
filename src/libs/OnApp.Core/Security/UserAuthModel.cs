namespace OnApp.Core.Security
{
    public class UserAuthModel
    {
        public int Id { get; set; }
        public string Inn { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public IEnumerable<string> Modules { get; set; }
        public bool IsAdmin { get; set; }
        public int? LanguageId { get; set; }
        public string LanguageCode { get; set; }
        public string Pinfl { get; set; }
        public int ParentOrganizationId { get; set; }
        public int? OrganizationId { get; set; }
        public int? PositionId { get; set; }

        public void ResolveModules()
        {
            if (IsAdmin)
                Modules = Enum.GetNames(typeof(ModuleCode))
                                .ToHashSet();
        }
    }
}
