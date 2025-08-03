namespace GameHub.WebApi.Common;

public static class AppExtension
{
    public static void ConfigurationDevEnvironment(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GameHub.WebApi v1"));
    }
}