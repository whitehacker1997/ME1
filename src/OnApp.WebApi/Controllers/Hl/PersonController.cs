using OnApp.BizLayer.PersonServices;
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
    public class PersonController : 
        GlobalController
    {
        private readonly IPersonService service;

        public PersonController(
            IPersonService service)
        {
            this.service = service;
        }

        [HttpPost]
        [Authorize(ModuleCode.PersonView)]
        [ProducesResponseType(typeof(PersonListDto), 200)]
        public PagedResult<PersonListDto> GetPersonList([FromBody] SortFilterPageOptions options)
            => service.GetPersonList(options);

        [HttpGet]
        [ProducesResponseType(typeof(SelectList<int>), 200)]
        public IActionResult GetPersonSelectList()
            => Ok(service.GetPersonAsSelectList());

        [HttpGet]
        [Authorize(ModuleCode.PersonCreate)]
        [ProducesResponseType(typeof(PersonDto), 200)]
        public IActionResult GetPerson()
            => Ok(service.GetPerson());

        [HttpGet("{Id}")]
        [Authorize(ModuleCode.PersonView)]
        [ProducesResponseType(typeof(PersonDto), 200)]
        public IActionResult GetPersonById(int Id)
        {
            if (ModelState.IsValid)
            {
                var person = service.GetPersonById(Id);

                if (service.IsValid)
                    return Ok(person);

                service.CopyErrorsToModelState(ModelState);
            }
            return ValidationProblem(ModelState);
        }

        [HttpPost]
        [Authorize(ModuleCode.PersonCreate)]
        [ProducesResponseType(typeof(HaveId<int>), 200)]
        public IActionResult CreatePerson([FromBody] CreatePersonDlDto dto)
        {
            if (ModelState.IsValid)
            {
                var person = service.CreatePerson(dto);

                if (service.IsValid)
                    return Ok(person);

                service.CopyErrorsToModelState(ModelState);
            }
            return ValidationProblem(ModelState);
        }

        [HttpPut]
        [Authorize(ModuleCode.PersonEdit)]
        [ProducesResponseType(200)]
        public IActionResult UpdatePerson([FromBody] UpdatePersonDlDto dto)
        {
            if (ModelState.IsValid)
            {
                service.UpdatePerson(dto);

                if (service.IsValid)
                    return Ok();

                service.CopyErrorsToModelState(ModelState);
            }
            return ValidationProblem(ModelState);
        }

        [HttpDelete("{Id}")]
        [Authorize(ModuleCode.PersonDelete)]
        [ProducesResponseType(200)]
        public IActionResult DeletePerson(int Id)
        {
            if (ModelState.IsValid)
            {
                service.DeletePerson(Id);

                if (service.IsValid)
                    return Ok();

                service.CopyErrorsToModelState(ModelState);
            }
            return ValidationProblem(ModelState);
        }
    }
}
