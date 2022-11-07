namespace Geraldapp.Domain.Entities;

/// <summary>
/// The contact skill
/// </summary>
public class ContactSkill
{
    /// <summary>
    /// Gets or sets the identifier.
    /// </summary>
    /// <value>
    /// The identifier.
    /// </value>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the contact identifier.
    /// </summary>
    /// <value>
    /// The contact identifier.
    /// </value>
    public Guid ContactId { get; set; }

    /// <summary>
    /// Gets or sets the skill identifier.
    /// </summary>
    /// <value>
    /// The skill identifier.
    /// </value>
    public Guid SkillId { get; set; }

    /// <summary>
    /// Gets or sets the level.
    /// </summary>
    /// <value>
    /// The level.
    /// </value>
    public SkillLevel Level { get; set; }
}