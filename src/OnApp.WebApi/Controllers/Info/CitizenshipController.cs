using OnApp.BizLayer.CitizenshipServices;
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
    public class CitizenshipController : 
        GlobalController
    {
        private readonly ICitizenshipService service;

        public CitizenshipController(
            ICitizenshipService service)
        {
            this.service = service;
        }

        [HttpPost]
        [Authorize(ModuleCode.CitizenshipView)]
        [ProducesResponseType(typeof(CitizenshipListDto), 200)]
        public PagedResult<CitizenshipListDto> GetCitizenshipList([FromBody] SortFilterPageOptions options)
            => service.GetCitizenshipList(options);

        [HttpGet]
        [ProducesResponseType(typeof(SelectList<int>), 200)]
        public IActionResult GetCitizenshipSelectList()
            => Ok(service.GetCitizenshipAsSelectList());

        [HttpGet]
        [Authorize(ModuleCode.CitizenshipCreate)]
        [ProducesResponseType(typeof(CitizenshipDto), 200)]
        public IActionResult GetCitizenship()
            => Ok(service.GetCitizenship());

        [HttpGet("{Id}")]
        [Authorize(ModuleCode.CitizenshipView)]
        [ProducesResponseType(typeof(CitizenshipDto), 200)]
        public IActionResult GetCitizenshipById(int Id)
        {
            if (ModelState.IsValid)
            {
                var Citizenship = service.GetCitizenshipById(Id);

                if (service.IsValid)
                    return Ok(Citizenship);

                service.CopyErrorsToModelState(ModelState);
            }
            return ValidationProblem(ModelState);
        }

        [HttpPost]
        [Authorize(ModuleCode.CitizenshipCreate)]
        [ProducesResponseType(typeof(HaveId<int>), 200)]
        public IActionResult CreateCitizenship([FromBody] CreateCitizenshipDlDto dto)
        {
            if (ModelState.IsValid)
            {
                var Citizenship = service.CreateCitizenship(dto);

                if (service.IsValid)
                    return Ok(Citizenship);

                service.CopyErrorsToModelState(ModelState);
            }
            return ValidationProblem(ModelState);
        }

        [HttpPut]
        [Authorize(ModuleCode.CitizenshipEdit)]
        [ProducesResponseType(200)]
        public IActionResult UpdateCitizenship([FromBody] UpdateCitizenshipDlDto dto)
        {
            if (ModelState.IsValid)
            {
                service.UpdateCitizenship(dto);

                if (service.IsValid)
                    return Ok();

                service.CopyErrorsToModelState(ModelState);
            }
            return ValidationProblem(ModelState);
        }

        [HttpDelete("{Id}")]
        [Authorize(ModuleCode.CitizenshipDelete)]
        [ProducesResponseType(200)]
        public IActionResult DeleteCitizenship(int Id)
        {
            if (ModelState.IsValid)
            {
                service.DeleteCitizenship(Id);

                if (service.IsValid)
                    return Ok();

                service.CopyErrorsToModelState(ModelState);
            }
            return ValidationProblem(ModelState);
        }
    }
}
