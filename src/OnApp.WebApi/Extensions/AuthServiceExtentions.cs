using OnApp.Core.Security;
using OnApp.WebApi.Security;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class CultureServiceExtentions
    {
        public static void ConfigureAuthServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<Global.Security.IAuthService>(x => x.GetService<IAuthService>());
        }
    }
}
