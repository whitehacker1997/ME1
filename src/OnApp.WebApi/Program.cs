using OnApp.WebApi;
using Global.DependencyIncection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

var builder = WebApplication.CreateBuilder(args);

AppSettings.Init(builder.Configuration.Get<AppSettings>());
// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.Converters.Add(new StringEnumConverter { AllowIntegerValues = false });
    options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Unspecified;
    options.SerializerSettings.DateFormatString = "dd.MM.yyyy";
}); ;
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGenNewtonsoftSupport();
builder.Services.ConfigureConfig();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureAuthServices();
builder.Services.ConfigureDbServices();
builder.Services.ConfigureGenericServices();


builder.Services.AddMemoryCache();
builder.Services.ConfigureSwaggerServices();
builder.Services.ConfigureCorsServices();


var app = builder.Build();

BaseServiceProvider.Initialize(() 
    => app.Services.GetService<IHttpContextAccessor>().HttpContext.RequestServices);

// Configure the HTTP request pipeline.
/*if (app.Environment.IsDevelopment())
{*/
    app.UseSwagger();
    app.UseSwaggerUI();
/*}*/
app.ConfigureCors();
//app.UseHttpsRedirection();

app.UseRouting();


app.UseAuthorization();

app.MapControllers();

app.Run();
