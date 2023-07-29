using OnApp.BizLayer.RoomServices;
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
    public class RoomController : 
        GlobalController
    {
        private readonly IRoomService service;

        public RoomController(
            IRoomService service)
        {
            this.service = service;
        }

        [HttpPost]
        [Authorize(ModuleCode.RoomView)]
        [ProducesResponseType(typeof(RoomListDto), 200)]
        public PagedResult<RoomListDto> GetRoomList([FromBody] SortFilterPageOptions options)
            => service.GetRoomList(options);

        [HttpGet]
        [ProducesResponseType(typeof(SelectList<int>), 200)]
        public IActionResult GetRoomSelectList()
            => Ok(service.GetRoomAsSelectList());

        [HttpGet]
        [Authorize(ModuleCode.RoomCreate)]
        [ProducesResponseType(typeof(RoomDto), 200)]
        public IActionResult GetRoom()
            => Ok(service.GetRoom());

        [HttpGet("{Id}")]
        [Authorize(ModuleCode.RoomView)]
        [ProducesResponseType(typeof(RoomDto), 200)]
        public IActionResult GetRoomById(int Id)
        {
            if (ModelState.IsValid)
            {
                var Room = service.GetRoomById(Id);

                if (service.IsValid)
                    return Ok(Room);

                service.CopyErrorsToModelState(ModelState);
            }
            return ValidationProblem(ModelState);
        }

        [HttpPost]
        [Authorize(ModuleCode.RoomCreate)]
        [ProducesResponseType(typeof(HaveId<int>), 200)]
        public IActionResult CreateRoom([FromBody] CreateRoomDlDto dto)
        {
            if (ModelState.IsValid)
            {
                var Room = service.CreateRoom(dto);

                if (service.IsValid)
                    return Ok(Room);

                service.CopyErrorsToModelState(ModelState);
            }
            return ValidationProblem(ModelState);
        }

        [HttpPut]
        [Authorize(ModuleCode.RoomEdit)]
        [ProducesResponseType(200)]
        public IActionResult UpdateRoom([FromBody] UpdateRoomDlDto dto)
        {
            if (ModelState.IsValid)
            {
                service.UpdateRoom(dto);

                if (service.IsValid)
                    return Ok();

                service.CopyErrorsToModelState(ModelState);
            }
            return ValidationProblem(ModelState);
        }

        [HttpDelete("{Id}")]
        [Authorize(ModuleCode.RoomDelete)]
        [ProducesResponseType(200)]
        public IActionResult DeleteRoom(int Id)
        {
            if (ModelState.IsValid)
            {
                service.DeleteRoom(Id);

                if (service.IsValid)
                    return Ok();

                service.CopyErrorsToModelState(ModelState);
            }
            return ValidationProblem(ModelState);
        }
    }
}
