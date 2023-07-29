using OnApp.DataLayer.Repository;
using Global.Models;
using StatusGeneric;

namespace OnApp.BizLayer.EmployeeServices;

public interface IEmployeeService : 
    IStatusGeneric
{
    PagedResult<EmployeeListDto> GetEmployeeList(SortFilterPageOptions filter);
    EmployeeDto GetEmployee();
    EmployeeDto GetEmployeeById(int id);
    SelectList<int> GetEmployeeAsSelectList(EmployeeSelectListFilterDto filter);
    HaveId<int> CreateEmployee(CreateEmployeeDlDto dto);
    void UpdateEmployee(UpdateEmployeeDlDto dto);
    void DeleteEmployee(int id);
}

