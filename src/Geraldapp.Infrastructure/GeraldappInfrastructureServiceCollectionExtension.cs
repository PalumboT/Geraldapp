namespace Geraldapp.Infrastructure;

using Microsoft.Extensions.DependencyInjection;

using Geraldapp.Domain.Services;
using Geraldapp.Infrastructure.Services;
using Geraldapp.Infrastructure.Validators;

/// <summary>
/// The Geraldapp infrastructure service collection extension
/// </summary>
public static class GeraldappInfrastructureServiceCollectionExtension
{
    /// <summary>
    /// Adds the geraldapp infrastructure.
    /// </summary>
    /// <param name="services">The services.</param>
    public static void AddGeraldappInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IContactService, ContactService>();
        services.AddScoped<IContactSkillService, ContactSkillService>();
        services.AddScoped<ISkillService, SkillService>();

        services.AddScoped<ContactSkillInjectionValidator>(); 
    }
}
