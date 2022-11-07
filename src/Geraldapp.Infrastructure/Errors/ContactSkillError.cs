namespace Geraldapp.Infrastructure.Errors;

using Geraldapp.Domain.Models;

/// <summary>
/// The contact skill error
/// </summary>
public static class ContactSkillError
{
    /// <summary>
    /// Gets the contact not found.
    /// </summary>
    /// <value>
    /// The contact not found.
    /// </value>
    public static ResultError NotFound => new ResultError
    {
        Code = 14220,
        Description = "Contact skill not found"
    };

    /// <summary>
    /// Gets the error occured while getting the contact.
    /// </summary>
    /// <value>
    /// The error occured while getting the contact.
    /// </value>
    public static ResultError ErrorOccuredWhileGetting => new ResultError
    {
        Code = 14221,
        Description = "An error occured while getting the contact skill"
    };

    /// <summary>
    /// Gets the error occured while creating.
    /// </summary>
    /// <value>
    /// The error occured while creating.
    /// </value>
    public static ResultError ErrorOccuredWhileCreating => new ResultError
    {
        Code = 14222,
        Description = "An error occured while creating the contact skill"
    };

    /// <summary>
    /// Gets the error occured while deleting.
    /// </summary>
    /// <value>
    /// The error occured while deleting.
    /// </value>
    public static ResultError ErrorOccuredWhileDeleting => new ResultError
    {
        Code = 14223,
        Description = "An error occured while deleting the contact skill"
    };

    /// <summary>
    /// Gets the error occured while deleting.
    /// </summary>
    /// <value>
    /// The error occured while deleting.
    /// </value>
    public static ResultError ErrorOccuredWhileUpdating => new ResultError
    {
        Code = 14224,
        Description = "An error occured while updating the contact skill"
    };

    /// <summary>
    /// Gets the has already the skill.
    /// </summary>
    /// <value>
    /// The has already the skill.
    /// </value>
    public static ResultError HasAlreadyTheSkill => new ResultError
    {
        Code = 14225,
        Description = "The contact has already this skill"
    };

    /// <summary>
    /// Gets the error occured while adding skill.
    /// </summary>
    /// <value>
    /// The error occured while adding skill.
    /// </value>
    public static ResultError ErrorOccuredWhileAddingSkill => new ResultError
    {
        Code = 14226,
        Description = "An error occured while adding the skill to the contact"
    };

    /// <summary>
    /// Gets the dont have the skill.
    /// </summary>
    /// <value>
    /// The dont have the skill.
    /// </value>
    public static ResultError DontHaveTheSkill => new ResultError
    {
        Code = 14227,
        Description = "The contact don't have this skill"
    };

    /// <summary>
    /// Gets the error occured while removing skill.
    /// </summary>
    /// <value>
    /// The error occured while removing skill.
    /// </value>
    public static ResultError ErrorOccuredWhileRemovingSkill => new ResultError
    {
        Code = 14228,
        Description = "An error occured while removing the skill to the contact"
    };
}

