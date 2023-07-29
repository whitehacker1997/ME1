using OnApp.BizLayer.DistrictServices;
using OnApp.Core.Security;
using OnApp.DataLayer.Repository;
using Global;
using Global.Models;
using Microsoft.AspNetCore.Mvc;

namespace OnApp.WebApi.Controllers.Info
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class DistrictController : 
        GlobalController
    {
        private readonly IDistrictService service;

        public DistrictController(
            IDistrictService service)
        {
            this.service = service;
        }
        [HttpPost]
        [Authorize(ModuleCode.DistrictView)]
        [ProducesResponseType(typeof(DistrictListDto), 200)]
        public PagedResult<DistrictListDto> GetDistrictList([FromBody] SortFilterPageOptions options)
            => service.GetDistrictList(options);

        [HttpGet]
        [ProducesResponseType(typeof(SelectList<int>), 200)]
        public IActionResult GetDistrictSelectList()
            => Ok(service.GetDistrictAsSelectList());

        [HttpGet]
        [Authorize(ModuleCode.DistrictCreate)]
        [ProducesResponseType(typeof(DistrictDto), 200)]
        public IActionResult GetDistrict()
            => Ok(service.GetDistrict());


        [HttpGet("{Id}")]
        [Authorize(ModuleCode.DistrictView)]
        [ProducesResponseType(typeof(DistrictDto), 200)]
        public IActionResult GetDistrictById(int Id)
        {
            if (ModelState.IsValid)
            {
                var District = service.GetDistrictById(Id);

                if (service.IsValid)
                    return Ok(District);

                service.CopyErrorsToModelState(ModelState);
            }
            return ValidationProblem(ModelState);
        }

        [HttpPost]
        [Authorize(ModuleCode.DistrictCreate)]
        [ProducesResponseType(typeof(HaveId<int>), 200)]
        public IActionResult CreateDistrict([FromBody] CreateDistrictDlDto dto)
        {
            if (ModelState.IsValid)
            {
                var District = service.CreateDistrict(dto);

                if (service.IsValid)
                    return Ok(District);

                service.CopyErrorsToModelState(ModelState);
            }
            return ValidationProblem(ModelState);
        }

        [HttpPut]
        [Authorize(ModuleCode.DistrictEdit)]
        [ProducesResponseType(200)]
        public IActionResult UpdateDistrict([FromBody] UpdateDistrictDlDto dto)
        {
            if (ModelState.IsValid)
            {
                service.UpdateDistrict(dto);

                if (service.IsValid)
                    return Ok();

                service.CopyErrorsToModelState(ModelState);
            }
            return ValidationProblem(ModelState);
        }

        [HttpDelete("{Id}")]
        [Authorize(ModuleCode.DistrictDelete)]
        [ProducesResponseType(200)]
        public IActionResult DeleteDistrict(int Id)
        {
            if (ModelState.IsValid)
            {
                service.DeleteDistrict(Id);

                if (service.IsValid)
                    return Ok();

                service.CopyErrorsToModelState(ModelState);
            }
            return ValidationProblem(ModelState);
        }
    }
}
