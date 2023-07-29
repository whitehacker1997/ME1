using Global.Attributes;
using Global.Models;

namespace OnApp.DataLayer.Repository;
public class UpdateEmployeeDlDto :
     EmployeeDlDto<UpdateEmployeeDlDto>,
     IHaveIdProp<int>
{
    [LocalizedRequired]
    [LocalizedRange(1, int.MaxValue)]
    public int Id { get; set; }
    [LocalizedRequired]
    [LocalizedRange(1, int.MaxValue)]
    public int StateId { get; set; }
/*
    public new int PersonId { get => base.PersonId; internal set => base.PersonId = value; }*/
}
