using OnApp.BizLayer.RegionServices;
using OnApp.Core.Security;
using OnApp.DataLayer.Repository;
using Global;
using Global.Models;
using Microsoft.AspNetCore.Mvc;

namespace OnApp.WebApi.Controllers.Info
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class RegionController : 
        GlobalController
    {
        private readonly IRegionService service;

        public RegionController(
            IRegionService service)
        {
            this.service = service;
        }
        [HttpPost]
        [Authorize(ModuleCode.RegionView)]
        [ProducesResponseType(typeof(RegionListDto), 200)]
        public PagedResult<RegionListDto> GetRegionList([FromBody] SortFilterPageOptions options)
            => service.GetRegionList(options);

        [HttpGet]
        [ProducesResponseType(typeof(SelectList<int>), 200)]
        public IActionResult GetRegionSelectList()
            => Ok(service.GetRegionAsSelectList());

        [HttpGet]
        [Authorize(ModuleCode.RegionCreate)]
        [ProducesResponseType(typeof(RegionDto), 200)]
        public IActionResult GetRegion()
            => Ok(service.GetRegion());


        [HttpGet("{Id}")]
        [Authorize(ModuleCode.RegionView)]
        [ProducesResponseType(typeof(RegionDto), 200)]
        public IActionResult GetRegionById(int Id)
        {
            if (ModelState.IsValid)
            {
                var Region = service.GetRegionById(Id);

                if (service.IsValid)
                    return Ok(Region);

                service.CopyErrorsToModelState(ModelState);
            }
            return ValidationProblem(ModelState);
        }

        [HttpPost]
        [Authorize(ModuleCode.RegionCreate)]
        [ProducesResponseType(typeof(HaveId<int>), 200)]
        public IActionResult CreateRegion([FromBody] CreateRegionDlDto dto)
        {
            if (ModelState.IsValid)
            {
                var Region = service.CreateRegion(dto);

                if (service.IsValid)
                    return Ok(Region);

                service.CopyErrorsToModelState(ModelState);
            }
            return ValidationProblem(ModelState);
        }

        [HttpPut]
        [Authorize(ModuleCode.RegionEdit)]
        [ProducesResponseType(200)]
        public IActionResult UpdateRegion([FromBody] UpdateRegionDlDto dto)
        {
            if (ModelState.IsValid)
            {
                service.UpdateRegion(dto);

                if (service.IsValid)
                    return Ok();

                service.CopyErrorsToModelState(ModelState);
            }
            return ValidationProblem(ModelState);
        }

        [HttpDelete("{Id}")]
        [Authorize(ModuleCode.RegionDelete)]
        [ProducesResponseType(200)]
        public IActionResult DeleteRegion(int Id)
        {
            if (ModelState.IsValid)
            {
                service.DeleteRegion(Id);

                if (service.IsValid)
                    return Ok();

                service.CopyErrorsToModelState(ModelState);
            }
            return ValidationProblem(ModelState);
        }
    }
}
