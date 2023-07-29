using Microsoft.AspNetCore.Mvc.Filters;

namespace OnApp.WebApi
{
    [AttributeUsage(AttributeTargets.Method)]
    public class AllowAnonymousAttribute :
        Attribute,
        IFilterMetadata
    {
    }
}
