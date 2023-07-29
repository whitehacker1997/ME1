using Microsoft.AspNetCore.Mvc.Filters;

namespace Global.Security
{
    [AttributeUsage(AttributeTargets.Method)]
    public class AllowAnonymousAttribute : Attribute, IFilterMetadata
    {

    }
}
