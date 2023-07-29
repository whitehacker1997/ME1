using OnApp.BizLayer.PersonServices;
using OnApp.DataLayer.Repository;
using GenericServices;

namespace OnApp.BizLayer.EmployeeServices;

public class EmployeeDto : 
    UpdateEmployeeDlDto,
    ILinkToEntity<Employee>
{
    public string? ParentOrganizationName { get; set; }
    public string OrganizationName { get; set; } = null!;
    public string PositionName { get; set; } = null!;
    public string StateName { get; set; } = null!;
    public new PersonDto Person { get; set; } = new();
}

