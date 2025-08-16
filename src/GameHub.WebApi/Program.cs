using System.Text.Json.Serialization;
using GameHub.Application;
using GameHub.Infrastructure;
using GameHub.WebApi.Common;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "GameHub.WebApi", Version = "v1" });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.ConfigurationDevEnvironment();
}

app.MapControllers();
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseAuthentication();

app.Run();

