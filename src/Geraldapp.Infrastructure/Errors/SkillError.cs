namespace Geraldapp.Infrastructure.Errors;

using Geraldapp.Domain.Models;

/// <summary>
/// The skill error
/// </summary>
public static class SkillError
{
    /// <summary>
    /// Gets the error occured while getting all.
    /// </summary>
    /// <value>
    /// The error occured while getting all.
    /// </value>
    public static ResultError ErrorOccuredWhileGettingAll => new ResultError
    {
        Code = 13220,
        Description = "An error occured while deleting all skill"
    };

    /// <summary>
    /// Gets the error occured while getting.
    /// </summary>
    /// <value>
    /// The error occured while getting.
    /// </value>
    public static ResultError ErrorOccuredWhileGetting => new ResultError
    {
        Code = 13221,
        Description = "An error occured while deleting the skill"
    };

    /// <summary>
    /// Gets the not found.
    /// </summary>
    /// <value>
    /// The not found.
    /// </value>
    public static ResultError NotFound => new ResultError
    {
        Code = 13222,
        Description = "Skill not found"
    };
}

