using OnApp.BizLayer.RoleServices;
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
    public class RoleController : 
        GlobalController
    {
        private readonly IRoleService service;

        public RoleController(
            IRoleService service)
        {
            this.service = service;
        }

        [HttpPost]
        [Authorize(ModuleCode.RoleView)]
        [ProducesResponseType(typeof(RoleListDto), 200)]
        public PagedResult<RoleListDto> GetRoleList([FromBody] SortFilterPageOptions options)
            => service.GetRoleList(options);

        [HttpGet]
        [ProducesResponseType(typeof(SelectList<int>), 200)]
        public IActionResult GetRoleSelectList()
            => Ok(service.GetRoleAsSelectList());

        [HttpGet]
        [Authorize(ModuleCode.RoleCreate)]
        [ProducesResponseType(typeof(RoleDto), 200)]
        public IActionResult GetRole()
            => Ok(service.GetRole());

        [HttpGet("{Id}")]
        [Authorize(ModuleCode.RoleView)]
        [ProducesResponseType(typeof(RoleDto), 200)]
        public IActionResult GetRoleById(int Id)
        {
            if (ModelState.IsValid)
            {
                var Role = service.GetRoleById(Id);

                if (service.IsValid)
                    return Ok(Role);

                service.CopyErrorsToModelState(ModelState);
            }
            return ValidationProblem(ModelState);
        }

        [HttpPost]
        [Authorize(ModuleCode.RoleCreate)]
        [ProducesResponseType(typeof(HaveId<int>), 200)]
        public IActionResult CreateRole([FromBody] CreateRoleDlDto dto)
        {
            if (ModelState.IsValid)
            {
                var Role = service.CreateRole(dto);

                if (service.IsValid)
                    return Ok(Role);

                service.CopyErrorsToModelState(ModelState);
            }
            return ValidationProblem(ModelState);
        }

        [HttpPut]
        [Authorize(ModuleCode.RoleEdit)]
        [ProducesResponseType(200)]
        public IActionResult UpdateRole([FromBody] UpdateRoleDlDto dto)
        {
            if (ModelState.IsValid)
            {
                service.UpdateRole(dto);

                if (service.IsValid)
                    return Ok();

                service.CopyErrorsToModelState(ModelState);
            }
            return ValidationProblem(ModelState);
        }

        [HttpDelete("{Id}")]
        [Authorize(ModuleCode.RoleDelete)]
        [ProducesResponseType(200)]
        public IActionResult DeleteRole(int Id)
        {
            if (ModelState.IsValid)
            {
                service.DeleteRole(Id);

                if (service.IsValid)
                    return Ok();

                service.CopyErrorsToModelState(ModelState);
            }
            return ValidationProblem(ModelState);
        }
    }
}
