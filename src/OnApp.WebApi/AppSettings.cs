using OnApp.Core.Configurations;
using Global.Configs;
using Global.Security;

namespace OnApp.WebApi
{
    public class AppSettings
    {
        public static AppSettings Instance { get; private set; } = new();

        public static void Init(AppSettings instance) =>
            Instance = instance;

        public CultureConfig Culture { get; set; } = new();
        public DatabaseConfig Database { get; set; } = new();
        public CorsConfig Cors { get; set; } = new();
        public SwaggerConfig Swagger { get; set; } = new();
        public JwtConfig Jwt { get; set; } = new();
        public SystemConfig System { get; set; } = new();
    }
    public class DatabaseConfig
    {
        public DbConnectionConfig PgSql { get; set; }
    }
}
