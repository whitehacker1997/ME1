using OnApp.WebApi;

namespace Microsoft.AspNetCore.Builder
{
    public static class CorsAppBuilderExtensions
    {
        public static void ConfigureCors(this IApplicationBuilder applicationBuilder)
        {
            if (AppSettings.Instance.Cors.UseCors)
                applicationBuilder.UseCors("AllowedOrigns");
            else
                applicationBuilder.UseCors("AllowAll");
        }
    }
}
