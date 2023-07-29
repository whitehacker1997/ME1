using OnApp.BizLayer.PositionServices;
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
    public class PositionController : 
        GlobalController
    {
        private readonly IPositionService service;

        public PositionController(
            IPositionService service)
        {
            this.service = service;
        }

        [HttpPost]
        [Authorize(ModuleCode.PositionView)]
        [ProducesResponseType(typeof(PositionListDto), 200)]
        public PagedResult<PositionListDto> GetPositionList([FromBody] SortFilterPageOptions options)
            => service.GetPositionList(options);

        [HttpGet]
        [ProducesResponseType(typeof(SelectList<int>), 200)]
        public IActionResult GetPositionSelectList()
            => Ok(service.GetPositionAsSelectList());

        [HttpGet]
        [Authorize(ModuleCode.PositionCreate)]
        [ProducesResponseType(typeof(PositionDto), 200)]
        public IActionResult GetPosition()
            => Ok(service.GetPosition());

        [HttpGet("{Id}")]
        [Authorize(ModuleCode.PositionView)]
        [ProducesResponseType(typeof(PositionDto), 200)]
        public IActionResult GetPositionById(int Id)
        {
            if (ModelState.IsValid)
            {
                var Position = service.GetPositionById(Id);

                if (service.IsValid)
                    return Ok(Position);

                service.CopyErrorsToModelState(ModelState);
            }
            return ValidationProblem(ModelState);
        }

        [HttpPost]
        [Authorize(ModuleCode.PositionCreate)]
        [ProducesResponseType(typeof(HaveId<int>), 200)]
        public IActionResult CreatePosition([FromBody] CreatePositionDlDto dto)
        {
            if (ModelState.IsValid)
            {
                var Position = service.CreatePosition(dto);

                if (service.IsValid)
                    return Ok(Position);

                service.CopyErrorsToModelState(ModelState);
            }
            return ValidationProblem(ModelState);
        }

        [HttpPut]
        [Authorize(ModuleCode.PositionEdit)]
        [ProducesResponseType(200)]
        public IActionResult UpdatePosition([FromBody] UpdatePositionDlDto dto)
        {
            if (ModelState.IsValid)
            {
                service.UpdatePosition(dto);

                if (service.IsValid)
                    return Ok();

                service.CopyErrorsToModelState(ModelState);
            }
            return ValidationProblem(ModelState);
        }

        [HttpDelete("{Id}")]
        [Authorize(ModuleCode.PositionDelete)]
        [ProducesResponseType(200)]
        public IActionResult DeletePosition(int Id)
        {
            if (ModelState.IsValid)
            {
                service.DeletePosition(Id);

                if (service.IsValid)
                    return Ok();

                service.CopyErrorsToModelState(ModelState);
            }
            return ValidationProblem(ModelState);
        }
    }
}
