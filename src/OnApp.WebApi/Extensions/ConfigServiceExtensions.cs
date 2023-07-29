using OnApp.WebApi;
using Global.Helpers;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ConfigServiceExtensions
    {
        public static void ConfigureConfig(this IServiceCollection services)
        {
            services.AddSingleton(AppSettings.Instance.Culture);
            services.AddSingleton(AppSettings.Instance.Jwt);
            services.AddSingleton(AppSettings.Instance.System);
            services.AddScoped<ICultureHelper, CultureHelper>();
        }
    }
}
