using OnApp.BizLayer.PersonServices;
using OnApp.DataLayer.Repository;
using GenericServices;

namespace OnApp.BizLayer.UserServices;

public class UserDto : 
    UpdateUserDlDto,
    ILinkToEntity<User>
{
    public string OrganizationName { get; set; } = null!;
    public string? ParentOrganizationName { get; set; }
    public string StateName { get; set; } = null!;
    public string PersonName { get; set; } = null!;
    public PersonDto Person { get; set; } = new();
}
