using OnApp.Core;
using Global.Attributes;
using Global.EF;

namespace OnApp.DataLayer.Repository;

public class EmployeeDlDto<TDto> :
    EntityDto<TDto, Employee>
    where TDto : EmployeeDlDto<TDto>
{
    [LocalizedRequired]
    [LocalizedRange(1, int.MaxValue)]
    public int OrganizationId { get; set; }
    [LocalizedRequired]
    public string? PhoneNumber { get; set; }
    [LocalizedRequired]
    [LocalizedRange(1, int.MaxValue)]
    public int PositionId { get; set; }
    public int PersonId { get; set; }
    public CreatePersonDlDto Person { get; set; } = new();
    public override Employee CreateEntity()
    {
        var entity = base.CreateEntity();
        entity.StateId = StateIdConst.ACTIVE;
        return entity;
    }
}
