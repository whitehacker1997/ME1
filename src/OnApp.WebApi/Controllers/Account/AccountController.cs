using OnApp.BizLayer.AccountServices;
using OnApp.DataLayer.Repository;
using Global;
using Microsoft.AspNetCore.Mvc;

namespace OnApp.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class AccountController :
        GlobalController
    {
        private readonly IAccountService service;

        public AccountController(IAccountService service)
        {
            this.service = service;
        }

        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(type: typeof(LoginResultDto), statusCode: 200)]
        public IActionResult Login(LoginDto dto)
        {
            if (ModelState.IsValid)
            {
                var result = service.Login(dto);

                if (service.IsValid)
                    return Ok(result);

                service.CopyErrorsToModelState(modelState: ModelState);
            }

            return ValidationProblem(ModelState);
        }

        [HttpGet]
        [ProducesResponseType(type: typeof(AccountUserDto), statusCode: 200)]
        public IActionResult GetUserInfo()
            => Ok(service.GetUserInfo());

        [HttpPut]
        public IActionResult ChangeLanguage(ChangeUserLanguageDlDto dto)
        {
            if (ModelState.IsValid)
            {
                service.ChangeLanguage(dto);

                if (service.IsValid)
                    return Ok();

                service.CopyErrorsToModelState(modelState: ModelState);
            }

            return ValidationProblem(ModelState);
        }

        [HttpPut]
        public IActionResult ChangePassword(ChangePasswordDlDto dto)
        {
            if (ModelState.IsValid)
            {
                service.ChangePassword(dto);

                if (service.IsValid)
                    return Ok();

                service.CopyErrorsToModelState(modelState: ModelState);
            }

            return ValidationProblem(ModelState);
        }
    }
}
