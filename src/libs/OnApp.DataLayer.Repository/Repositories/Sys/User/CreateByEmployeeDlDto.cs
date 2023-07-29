using Global.Attributes;

namespace OnApp.DataLayer.Repository;

public class CreateByEmployeeDlDto : 
    UserDlDto<CreateByEmployeeDlDto>
{
    [LocalizedRequired]
    [LocalizedRange(1,int.MaxValue)]
    public int EmployeeId { get; set; }
    public override string Password { get => base.Password; set => base.Password = value; }
}
