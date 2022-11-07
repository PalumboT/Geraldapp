namespace Geraldapp.WebApi.Config;

/// <summary>
/// The web application builder extensions
/// </summary>
public static class WebApplicationBuilderExtensions
{
    /// <summary>
    /// Configures the web application.
    /// </summary>
    /// <param name="builder">The builder.</param>
    public static void ConfigureWebApplication(this WebApplicationBuilder builder)
    {
        builder.Configuration
            .AddJsonFile("appsettings.json", false, true)
            .AddJsonFile("appsettings.{builder.Environment.EnvironmentName}.json", true)
            .AddEnvironmentVariables();

        builder.WebHost
            .ConfigureKestrel(serverOptions =>
            {
                serverOptions.AddServerHeader = false;
                serverOptions.Limits.KeepAliveTimeout = TimeSpan.MaxValue;
            })
            .UseIISIntegration();
    }
}
