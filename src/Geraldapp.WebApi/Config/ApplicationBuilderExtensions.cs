namespace Geraldapp.WebApi.Config;

using Geraldapp.Persistence;

/// <summary>
/// The application builder extension
/// </summary>
public static class ApplicationBuilderExtensions
{
    /// <summary>
    /// Configures the application.
    /// </summary>
    /// <param name="app">The application.</param>
    public static void ConfigureApplication(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseGrealdappSeeds();
        app.UseRouting();

        app.UseSwagger();

        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/geraldapp-v1/swagger.json", "geraldapp");
        });

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}