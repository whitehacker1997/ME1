using OnApp.DataLayer.Repository;
using GenericServices;

namespace OnApp.BizLayer.EmployeeServices
{
    public record EmployeeListDto :
        ILinkToEntity<Employee>
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string DocumentInfo { get; set; } = null!;
        public string? Pinfl { get; set; }
        public int? ParentOrganizationId { get; set; }
        public string? ParentOrganizationName { get; set; }
        public int OrganizationId { get; set; }
        public string OrganizationName { get; set; } = null!;
        public string PositionName { get; set; } = null!;
        public string StateName { get; set; } = null!;
        public bool IsDoctor { get; set; }
    }
}
