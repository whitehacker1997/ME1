using OnApp.DataLayer.Repository;
using GenericServices;
using Global.Models;

namespace OnApp.BizLayer.UserServices;

public class UserListDto : 
    ILinkToEntity<User>,
    IHaveIdProp<int>
{
    public int Id { get; set; }
    public string UserName { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public int? ParentOrganizationId { get; set; }
    public int OrganizationId { get; set; }
    public int? EmployeeId { get; set; }
    public string? Email { get; set; }
    public string PhoneNumber { get; set; } = null!;

    public string StateName { get; set; } = null!;
    public List<string> Roles { get; set; } = new();
    public string? ParentOrganizationName { get; set; }
    public string OrganizationName { get; set; } = null!; 
}
