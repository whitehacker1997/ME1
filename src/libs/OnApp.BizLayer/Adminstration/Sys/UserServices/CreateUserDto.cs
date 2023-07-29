using OnApp.DataLayer.Repository;

namespace OnApp.BizLayer.UserServices;

public class CreateUserDto : 
    CreateUserDlDto
{
    public CreatePersonDlDto? Person { get; set; } = new();
}
