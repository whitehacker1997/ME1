using Global.Attributes;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace Global.QueryObjects
{
    public class SwaggerExcludeFilter
        : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema,
                          SchemaFilterContext schemaFilterContext)
        {
            if (schema?.Properties == null || schemaFilterContext.Type == null)
                return;

            foreach (PropertyInfo propertyInfo in from
                                                      propInfo in schemaFilterContext.Type.GetProperties()
                                                  where
                                                      propInfo.GetCustomAttribute<SwaggerExcludeAttribute>() != null ||
                                                      propInfo.GetCustomAttribute<JsonIgnoreAttribute>() != null ||
                                                      propInfo.GetCustomAttribute<System.Text.Json.Serialization.JsonIgnoreAttribute>() != null
                                                  select propInfo)
            {
                if (schema.Properties.ContainsKey(propertyInfo.Name))
                    schema.Properties.Remove(propertyInfo.Name);
            }
        }
    }
}
