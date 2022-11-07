namespace Geraldapp.WebApi.Config;

using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Converters;

using Geraldapp.Application;
using Geraldapp.Infrastructure;
using Geraldapp.Persistence;

/// <summary>
/// The service collection extensions
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds the services.
    /// </summary>
    /// <param name="services">The services.</param>
    /// <param name="configuration">The configuration.</param>
    public static void AddServices(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddGeraldappContexts(configuration);
        services.AddGeraldappInfrastructure();

        services.AddRouting();

        // Add controllers
        services.AddControllers()
            .AddApplicationPart(typeof(GeraldappApplicationServiceCollectionExtension).Assembly)
            .AddNewtonsoftJson(options => options.SerializerSettings.Converters.Add(new StringEnumConverter()));

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("geraldapp-v1", new OpenApiInfo
            {
                Title = "geraldapp",
                Version = "v1",
                Description = "Geraldapp endpoint",
                Contact = new OpenApiContact
                {
                    Email = "tp@ggmail.com"
                }
            });
        });

        services.AddSwaggerGenNewtonsoftSupport();

        services.AddAutoMapper(
            typeof(GeraldappApplicationServiceCollectionExtension));
    }
}