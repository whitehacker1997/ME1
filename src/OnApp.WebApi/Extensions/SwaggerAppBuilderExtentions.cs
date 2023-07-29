namespace OnApp.WebApi.Extensions
{
    public static class SwaggerAppBuilderExtentions
    {
        public static void ConfigureSwagger(this IApplicationBuilder applicationBuilder)
        {
            if (AppSettings.Instance.Swagger.Enabled)
            {
                applicationBuilder.UseSwagger();
                applicationBuilder.UseSwaggerUI(options
                    => options.SwaggerEndpoint("/swagger/v1/swagger.json", "OnApp.WebApi v1"));
            }
        }
    }
}
