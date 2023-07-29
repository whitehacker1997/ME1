using OnApp.WebApi;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ConfigureCorsExtensions
    {
        public static void ConfigureCorsServices(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                    });
                options.AddPolicy("AllowedOrigns",
                    builder =>
                    {
                        if (AppSettings.Instance.Cors.UseCors)
                            builder
                                .WithOrigins(AppSettings.Instance.Cors.AllowedOrigns.Split(
                                    new string[] { "," ,";"},StringSplitOptions.None))
                                .AllowAnyHeader()
                                .AllowAnyMethod()
                                .AllowAnyHeader();
                        else
                            builder
                                .AllowAnyOrigin()
                                .AllowAnyMethod()
                                .AllowAnyHeader();
                    });
            });
        }
    }
}
