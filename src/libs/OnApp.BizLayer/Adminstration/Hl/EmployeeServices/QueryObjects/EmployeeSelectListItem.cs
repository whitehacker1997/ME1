using Global.Models;

namespace OnApp.BizLayer.EmployeeServices
{
    public class EmployeeSelectListItem<T> : 
        SelectListItem<T>
    {
        public string PassportInfo { get; set; } = null!;
        public int? ParentOrganizatonId { get; set; }
        public int OrganizatonId { get; set; }
        public string? ParentOrganizaton { get; set; }
        public string Organization { get; set; } = null!;
        public string Position { get; set; } = null!;
    }
}
