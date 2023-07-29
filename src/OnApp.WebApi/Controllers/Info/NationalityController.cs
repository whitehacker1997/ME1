using OnApp.BizLayer.NationalityServices;
using OnApp.Core.Security;
using OnApp.DataLayer.Repository;
using Global;
using Global.Models;
using Microsoft.AspNetCore.Mvc;

namespace OnApp.WebApi.Controllers.Info
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class NationalityController : 
        GlobalController
    {
        private readonly INationalityService service;

        public NationalityController(
            INationalityService service)
        {
            this.service = service;
        }
        [HttpPost]
        [Authorize(ModuleCode.NationalityView)]
        [ProducesResponseType(typeof(NationalityListDto), 200)]
        public PagedResult<NationalityListDto> GetNationalityList([FromBody] SortFilterPageOptions options)
            => service.GetNationalityList(options);

        [HttpGet]
        [ProducesResponseType(typeof(SelectList<int>), 200)]
        public IActionResult GetNationalitySelectList()
            => Ok(service.GetNationalityAsSelectList());

        [HttpGet]
        [Authorize(ModuleCode.NationalityCreate)]
        [ProducesResponseType(typeof(NationalityDto), 200)]
        public IActionResult GetNationality()
            => Ok(service.GetNationality());


        [HttpGet("{Id}")]
        [Authorize(ModuleCode.NationalityView)]
        [ProducesResponseType(typeof(NationalityDto), 200)]
        public IActionResult GetNationalityById(int Id)
        {
            if (ModelState.IsValid)
            {
                var Nationality = service.GetNationalityById(Id);

                if (service.IsValid)
                    return Ok(Nationality);

                service.CopyErrorsToModelState(ModelState);
            }
            return ValidationProblem(ModelState);
        }

        [HttpPost]
        [Authorize(ModuleCode.NationalityCreate)]
        [ProducesResponseType(typeof(HaveId<int>), 200)]
        public IActionResult CreateNationality([FromBody] CreateNationalityDlDto dto)
        {
            if (ModelState.IsValid)
            {
                var Nationality = service.CreateNationality(dto);

                if (service.IsValid)
                    return Ok(Nationality);

                service.CopyErrorsToModelState(ModelState);
            }
            return ValidationProblem(ModelState);
        }

        [HttpPut]
        [Authorize(ModuleCode.NationalityEdit)]
        [ProducesResponseType(200)]
        public IActionResult UpdateNationality([FromBody] UpdateNationalityDlDto dto)
        {
            if (ModelState.IsValid)
            {
                service.UpdateNationality(dto);

                if (service.IsValid)
                    return Ok();

                service.CopyErrorsToModelState(ModelState);
            }
            return ValidationProblem(ModelState);
        }

        [HttpDelete("{Id}")]
        [Authorize(ModuleCode.NationalityDelete)]
        [ProducesResponseType(200)]
        public IActionResult DeleteNationality(int Id)
        {
            if (ModelState.IsValid)
            {
                service.DeleteNationality(Id);

                if (service.IsValid)
                    return Ok();

                service.CopyErrorsToModelState(ModelState);
            }
            return ValidationProblem(ModelState);
        }
    }
}
