using Global.EF;

namespace OnApp.DataLayer.Repository;
public interface IEmployeeRepository :
    IBaseEntityRepository<int, Employee, CreateEmployeeDlDto, UpdateEmployeeDlDto>
{
}

