namespace Geraldapp.Persistence;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

using Geraldapp.Domain.Entities;
using Geraldapp.Persistence.Contexts;

/// <summary>
/// The Geraldapp persistence application builder extension
/// </summary>
public static class GeraldappPersistenceApplicationBuilderExtension
{
    /// <summary>
    /// Uses the grealdapp seeds.
    /// </summary>
    /// <param name="app">The application.</param>
    public static void UseGrealdappSeeds(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<GeraldappContext>();

        context.Add(new Contact
        {
            Id = Guid.Parse("aaaca2af-f3a6-4990-8121-aaaaee5f42c5"),
            FirstName = "Henry",
            LastName =  "Pasche",
            Email = "henry.pasche@gmail.com",
            MobilePhoneNumber = "+4185454554",
            Address = new ContactAddress
            {
                Line1 = "Rue du lol 12",
                Line2 = "",
                City = "Lausanne",
                PostalCode = "1110"
            }
        });

        context.Add(new Skill
        {
            Id = Guid.Parse("76cca2af-f3a6-4990-8121-aaaaee5f42c5"),
            Name = "Development"
        });

        context.Add(new Skill
        {
            Id = Guid.Parse("76cca2af-f3a6-4990-8121-e808ee5f42c5"),
            Name = "Frogs hunting"
        });

        context.SaveChangesAsync();
    }
}