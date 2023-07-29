using OnApp.BizLayer.OrganizationServices;
using OnApp.Core.Security;
using OnApp.DataLayer.Repository;
using Global;
using Global.Models;
using Microsoft.AspNetCore.Mvc;

namespace OnApp.WebApi.Controllers.Info
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class OrganizationController : 
        GlobalController
    {
        private readonly IOrganizationService service;

        public OrganizationController(
            IOrganizationService service)
        {
            this.service = service;
        }
        [HttpPost]
        [Authorize(ModuleCode.OrganizationView)]
        [ProducesResponseType(typeof(OrganizationListDto), 200)]
        public PagedResult<OrganizationListDto> GetOrganizationList([FromBody] SortFilterPageOptions options)
            => service.GetOrganizationList(options);

        [HttpGet]
        [ProducesResponseType(typeof(SelectList<int>), 200)]
        public IActionResult GetOrganizationSelectList()
            => Ok(service.GetOrganizationAsSelectList());

        [HttpGet]
        [Authorize(ModuleCode.OrganizationCreate)]
        [ProducesResponseType(typeof(OrganizationDto), 200)]
        public IActionResult GetOrganization()
            => Ok(service.GetOrganization());


        [HttpGet("{Id}")]
        [Authorize(ModuleCode.OrganizationView)]
        [ProducesResponseType(typeof(OrganizationDto), 200)]
        public IActionResult GetOrganizationById(int Id)
        {
            if (ModelState.IsValid)
            {
                var Organization = service.GetOrganizationById(Id);

                if (service.IsValid)
                    return Ok(Organization);

                service.CopyErrorsToModelState(ModelState);
            }
            return ValidationProblem(ModelState);
        }

        [HttpPost]
        [Authorize(ModuleCode.OrganizationCreate)]
        [ProducesResponseType(typeof(HaveId<int>), 200)]
        public IActionResult CreateOrganization([FromBody] CreateOrganizationDlDto dto)
        {
            if (ModelState.IsValid)
            {
                var Organization = service.CreateOrganization(dto);

                if (service.IsValid)
                    return Ok(Organization);

                service.CopyErrorsToModelState(ModelState);
            }
            return ValidationProblem(ModelState);
        }

        [HttpPut]
        [Authorize(ModuleCode.OrganizationEdit)]
        [ProducesResponseType(200)]
        public IActionResult UpdateOrganization([FromBody] UpdateOrganizationDlDto dto)
        {
            if (ModelState.IsValid)
            {
                service.UpdateOrganization(dto);

                if (service.IsValid)
                    return Ok();

                service.CopyErrorsToModelState(ModelState);
            }
            return ValidationProblem(ModelState);
        }

        [HttpDelete("{Id}")]
        [Authorize(ModuleCode.OrganizationDelete)]
        [ProducesResponseType(200)]
        public IActionResult DeleteOrganization(int Id)
        {
            if (ModelState.IsValid)
            {
                service.DeleteOrganization(Id);

                if (service.IsValid)
                    return Ok();

                service.CopyErrorsToModelState(ModelState);
            }
            return ValidationProblem(ModelState);
        }
    }
}
