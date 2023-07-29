using OnApp.BizLayer.EmployeeServices;
using OnApp.Core.Security;
using OnApp.DataLayer.Repository;
using Global;
using Global.Models;
using Microsoft.AspNetCore.Mvc;

namespace OnApp.WebApi.Controllers.Info
{
    [Route("[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class EmployeeController : 
        GlobalController
    {
        private readonly IEmployeeService service;

        public EmployeeController(
            IEmployeeService service)
        {
            this.service = service;
        }

        [HttpPost]
        [Authorize(ModuleCode.EmployeeView)]
        [ProducesResponseType(typeof(EmployeeListDto), 200)]
        public PagedResult<EmployeeListDto> GetEmployeeList([FromBody] SortFilterPageOptions options)
            => service.GetEmployeeList(options);

        [HttpGet]
        [ProducesResponseType(typeof(SelectList<int>), 200)]
        public IActionResult GetEmployeeSelectList(EmployeeSelectListFilterDto filter)
            => Ok(service.GetEmployeeAsSelectList(filter));

        [HttpGet]
        [Authorize(ModuleCode.EmployeeCreate)]
        [ProducesResponseType(typeof(EmployeeDto), 200)]
        public IActionResult GetEmployee()
            => Ok(service.GetEmployee());

        [HttpGet("{Id}")]
        [Authorize(ModuleCode.EmployeeView)]
        [ProducesResponseType(typeof(EmployeeDto), 200)]
        public IActionResult GetEmployeeById(int Id)
        {
            if (ModelState.IsValid)
            {
                var employee = service.GetEmployeeById(Id);

                if (service.IsValid)
                    return Ok(employee);

                service.CopyErrorsToModelState(ModelState);
            }
            return ValidationProblem(ModelState);
        }

        [HttpPost]
        [Authorize(ModuleCode.EmployeeCreate)]
        [ProducesResponseType(typeof(HaveId<int>), 200)]
        public IActionResult CreateEmployee([FromBody] CreateEmployeeDlDto dto)
        {
            if (ModelState.IsValid)
            {
                var employee = service.CreateEmployee(dto);

                if (service.IsValid)
                    return Ok(employee);

                service.CopyErrorsToModelState(ModelState);
            }
            return ValidationProblem(ModelState);
        }

        [HttpPut]
        [Authorize(ModuleCode.EmployeeEdit)]
        [ProducesResponseType(200)]
        public IActionResult UpdateEmployee([FromBody] UpdateEmployeeDlDto dto)
        {
            if (ModelState.IsValid)
            {
                service.UpdateEmployee(dto);

                if (service.IsValid)
                    return Ok();

                service.CopyErrorsToModelState(ModelState);
            }
            return ValidationProblem(ModelState);
        }

        [HttpDelete("{Id}")]
        [Authorize(ModuleCode.EmployeeDelete)]
        [ProducesResponseType(200)]
        public IActionResult DeleteEmployee(int Id)
        {
            if (ModelState.IsValid)
            {
                service.DeleteEmployee(Id);

                if (service.IsValid)
                    return Ok();

                service.CopyErrorsToModelState(ModelState);
            }
            return ValidationProblem(ModelState);
        }
    }
}
