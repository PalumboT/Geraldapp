namespace Geraldapp.Domain.Extensions;

using Geraldapp.Domain.Entities;

/// <summary>
/// The contact skill extension
/// </summary>
public static class ContactSkillExtension
{
    /// <summary>
    /// Updates the specified data.
    /// </summary>
    /// <param name="contactSkill">The contact skill.</param>
    /// <param name="data">The data.</param>
    public static void Update(this ContactSkill contactSkill, ContactSkill data)
    {
        contactSkill.Level = data.Level;
    }
}

