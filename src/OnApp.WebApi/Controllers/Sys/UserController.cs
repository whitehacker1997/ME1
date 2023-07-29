using OnApp.BizLayer.UserServices;
using OnApp.Core.Security;
using OnApp.DataLayer.Repository;
using Global;
using Global.Models;
using Microsoft.AspNetCore.Mvc;

namespace OnApp.WebApi.Controllers;

[Route("[controller]/[action]")]
[ApiController]
public class UserController :
    GlobalController
{
    private readonly IUserService service;

    public UserController(IUserService service)
    {
        this.service = service;
    }

    [HttpPost]
    [Authorize(ModuleCode.UserView, ModuleCode.BranchesUserView, ModuleCode.AllUserView)]
    public PagedResult<UserListDto> GetList([FromBody] SortFilterPageOptions dto)
        => service.GetUserList(dto);

    [HttpGet]
    [Authorize(ModuleCode.UserView, ModuleCode.BranchesUserView, ModuleCode.AllUserView)]
    [ProducesResponseType(typeof(UserDto), 200)]
    public IActionResult GetUser()
        => Ok(service.GetUser());


    [HttpGet("{id}")]
    [Authorize(ModuleCode.UserView, ModuleCode.BranchesUserView, ModuleCode.AllUserView)]
    [ProducesResponseType(typeof(UserDto), 200)]
    public IActionResult GetUserById(int id)
    {
        UserDto dto = service.GetUserById(id);

        if (service.IsValid)
            return Ok(dto);

        service.CopyErrorsToModelState(ModelState);

        return ValidationProblem(ModelState);
    }

    [HttpPost]
    [ProducesResponseType(typeof(SelectList<int>), 200)]
    public IActionResult GetUserAsSelectList([FromBody] UserSortFilterPageOptions options)
        => Ok(service.GetUserAsSelectList(options));

    [HttpPost]
    [Authorize(ModuleCode.UserCreate, ModuleCode.BranchesUserCreate, ModuleCode.AllUserCreate)]
    [ProducesResponseType(typeof(HaveId<int>), 200)]
    public IActionResult CreateUser(CreateUserDto dto)
    {
        if (ModelState.IsValid)
        {
            HaveId<int> result = service.CreateUser(dto);

            if (service.IsValid)
                return Ok(result);

            service.CopyErrorsToModelState(ModelState);
        }

        return ValidationProblem(ModelState);
    }

    [HttpPost]
    [Authorize(ModuleCode.UserCreate, ModuleCode.BranchesUserCreate, ModuleCode.AllUserCreate)]
    [ProducesResponseType(typeof(HaveId<int>), 200)]
    public IActionResult CreateUserByEmployee(CreateByEmployeeDlDto dto)
    {
        if (ModelState.IsValid)
        {
            HaveId<int> result = service.CreateUserByEmployee(dto);

            if (service.IsValid)
                return Ok(result);

            service.CopyErrorsToModelState(ModelState);
        }

        return ValidationProblem(ModelState);
    }

    [HttpPost]
    [Authorize(ModuleCode.UserEdit, ModuleCode.BranchesUserEdit, ModuleCode.AllUserEdit)]
    [ProducesResponseType(200)]
    public IActionResult UpdateUser(UpdateUserDlDto dto)
    {
        if (ModelState.IsValid)
        {
            service.UpdateUser(dto);

            if (service.IsValid)
                return Ok();

            service.CopyErrorsToModelState(ModelState);
        }

        return ValidationProblem(ModelState);
    }

    [HttpPost("{id}")]
    [Authorize(ModuleCode.UserDelete, ModuleCode.BranchesUserDelete, ModuleCode.AllUserDelete)]
    [ProducesResponseType(200)]
    public IActionResult DeleteUser(int id)
    {
        if (ModelState.IsValid)
        {
            service.DeleteUser(id);

            if (service.IsValid)
                return Ok();

            service.CopyErrorsToModelState(ModelState);
        }

        return ValidationProblem(ModelState);
    }

    [HttpGet]
    [ProducesResponseType(typeof(CreateUserDto), 200)]
    public IActionResult GetUserByDocInfo([FromQuery] UserDocInfoDto dto)
    {
        if (ModelState.IsValid)
        {
            var user = service.GetUserByDocInfo(dto);

            if (service.IsValid)
                return Ok(user);

            service.CopyErrorsToModelState(ModelState);
        }

        return ValidationProblem(ModelState);
    }

    [HttpPost]
    [ProducesResponseType(typeof(CheckUserNameRespDto), 200)]
    public IActionResult CheckUserName(CheckUserNameDto dto)
    {
        if (ModelState.IsValid)
        {
            var isBusy = service.IsUserNameBusy(dto);

            if (service.IsValid)
                return Ok(new CheckUserNameRespDto
                {
                    UserName = dto.UserName,
                    IsBusy = isBusy
                });

            service.CopyErrorsToModelState(ModelState);
        }

        return ValidationProblem(ModelState);
    }
}
