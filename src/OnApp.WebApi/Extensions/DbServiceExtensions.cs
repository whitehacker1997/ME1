using OnApp.DataLayer;
using OnApp.DataLayer.PgSql.EfCode;
using OnApp.DataLayer.Repository;
using OnApp.WebApi;
using Global.EF;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DbServiceExtensions
    {
        public static void ConfigureDbServices(this IServiceCollection services)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehaviour",true);

            services.AddDbContext<EfCoreContext, PgSqlContext>(
                options =>
                {
                    options
                            .UseNpgsql(AppSettings.Instance.Database.PgSql.ConnectionString);
                    options.EnableSensitiveDataLogging(true);
                });

            services.AddScoped<BaseDbContext>(serviceProvider 
                                => serviceProvider.GetService<EfCoreContext>());
        }
    }
}
