namespace Geraldapp.Persistence;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Geraldapp.Persistence.Contexts;

/// <summary>
/// The Geraldapp persistence service collection extension
/// </summary>
public static class GeraldappPersistenceServiceCollectionExtension
{
    /// <summary>
    /// Adds the geraldapp contacts contexts.
    /// </summary>
    /// <param name="services">The services.</param>
    /// <param name="configuration">The configuration.</param>
    public static void AddGeraldappContexts(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<GeraldappContext>();
    }
}
