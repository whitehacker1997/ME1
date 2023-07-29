using Global.Models;

namespace OnApp.BizLayer.EmployeeServices;

public static class EmployeeSelectList
{
    public static SelectList<int> AsSelectList(this IQueryable<EmployeeListDto> employee, EmployeeSelectListFilterDto filter)
        => new SelectList<int>(
                employee.Where(employee => filter.IsOnlyDoctors.HasValue ? employee.IsDoctor : true)
                    .Select(employee => new EmployeeSelectListItem<int>
                    {
                        Value = employee.Id,
                        Text = employee.FullName,
                        PassportInfo = employee.DocumentInfo,
                        ParentOrganizatonId = employee.ParentOrganizationId,
                        OrganizatonId = employee.OrganizationId,
                        ParentOrganizaton = employee.ParentOrganizationName,
                        Organization = employee.OrganizationName,
                        Position = employee.PositionName,
                    })
                );
}


