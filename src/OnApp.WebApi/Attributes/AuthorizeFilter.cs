using Global.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace OnApp.WebApi
{
    public class AuthorizeFilter : Attribute, IAuthorizationFilter
    {
        protected string[] ModuleCodes { get; }
        public AuthorizeFilter(string[] moduleCodes)
        {
            ModuleCodes = moduleCodes;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.Filters.Any(a => a is AllowAnonymousAttribute))
                return;

            var authService = (IAuthService)context.HttpContext.RequestServices.GetService(typeof(IAuthService));

            if (!authService!.IsAuthenticated)
                context.Result = new UnauthorizedResult();
            else if ((ModuleCodes?.Any()).GetValueOrDefault())
                if (!ModuleCodes.Any(moduleCode => authService.HasPermission(moduleCode)))
                    context.Result = new StatusCodeResult(403);
        }
    }
}
