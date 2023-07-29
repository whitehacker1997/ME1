using OnApp.BizLayer.CountryServices;
using OnApp.Core.Security;
using OnApp.DataLayer.Repository;
using Global;
using Global.Models;
using Microsoft.AspNetCore.Mvc;

namespace OnApp.WebApi.Controllers.Info
{
    [Authorize]
    [Route("[controller]/[action]")]
    [ApiController]
    public class CountryController :
        GlobalController
    {
        private readonly ICountryService service;

        public CountryController(ICountryService service)
        {
            this.service = service;
        }

        [HttpPost]
        [Authorize(ModuleCode.CountryView)]
        [ProducesResponseType(typeof(CountryListDto), 200)]
        public PagedResult<CountryListDto> GetCountryList([FromBody] SortFilterPageOptions options)
            => service.GetList(options);

        [HttpGet]
        [ProducesResponseType(typeof(SelectList<int>), 200)]
        public IActionResult GetCountrySelectList()
            => Ok(service.GetAsSelectList());

        [HttpGet]
        [Authorize(ModuleCode.CountryCreate)]
        [ProducesResponseType(typeof(CountryDto), 200)]
        public IActionResult GetCountry()
            => Ok(service.GetCountry());


        [HttpGet("{Id}")]
        [Authorize(ModuleCode.CountryView)]
        [ProducesResponseType(typeof(CountryDto), 200)]
        public IActionResult GetCountryById(int Id)
        {
            if (ModelState.IsValid)
            {
                var country = service.GetCountryById(Id);

                if (service.IsValid)
                    return Ok(country);

                service.CopyErrorsToModelState(ModelState);
            }
            return ValidationProblem(ModelState);
        }

        [HttpPost]
        [Authorize(ModuleCode.CountryCreate)]
        [ProducesResponseType(typeof(HaveId<int>), 200)]
        public IActionResult CreateCountry([FromBody] CreateCountryDlDto dto)
        {
            if (ModelState.IsValid)
            {
                var country = service.CreateCountry(dto);

                if (service.IsValid)
                    return Ok(country);

                service.CopyErrorsToModelState(ModelState);
            }
            return ValidationProblem(ModelState);
        }

        [HttpPut]
        [Authorize(ModuleCode.CountryEdit)]
        [ProducesResponseType(200)]
        public IActionResult UpdateCountry([FromBody] UpdateCountryDlDto dto)
        {
            if (ModelState.IsValid)
            {
                service.UpdateCountry(dto);

                if (service.IsValid)
                    return Ok();

                service.CopyErrorsToModelState(ModelState);
            }
            return ValidationProblem(ModelState);
        }

        [HttpDelete("{Id}")]
        [Authorize(ModuleCode.CountryDelete)]
        [ProducesResponseType(200)]
        public IActionResult DeleteCountry(int Id)
        {
            if (ModelState.IsValid)
            {
                service.DeleteCountry(Id);

                if (service.IsValid)
                    return Ok();

                service.CopyErrorsToModelState(ModelState);
            }
            return ValidationProblem(ModelState);
        }
    }
}
