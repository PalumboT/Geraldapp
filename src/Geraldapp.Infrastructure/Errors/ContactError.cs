namespace Geraldapp.Infrastructure.Errors;

using Geraldapp.Domain.Models;

/// <summary>
/// The contact error
/// </summary>
public static class ContactError
{
    /// <summary>
    /// Gets the contact not found.
    /// </summary>
    /// <value>
    /// The contact not found.
    /// </value>
    public static ResultError NotFound => new ResultError
    {
        Code = 12220,
        Description = "Contact not found"
    };

    /// <summary>
    /// Gets the error occured while getting the contact.
    /// </summary>
    /// <value>
    /// The error occured while getting the contact.
    /// </value>
    public static ResultError ErrorOccuredWhileGetting => new ResultError
    {
        Code = 12221,
        Description = "An error occured while getting the contact"
    };

    /// <summary>
    /// Gets the error occured while creating.
    /// </summary>
    /// <value>
    /// The error occured while creating.
    /// </value>
    public static ResultError ErrorOccuredWhileCreating => new ResultError
    {
        Code = 12222,
        Description = "An error occured while creating the contact"
    };

    /// <summary>
    /// Gets the error occured while deleting.
    /// </summary>
    /// <value>
    /// The error occured while deleting.
    /// </value>
    public static ResultError ErrorOccuredWhileDeleting => new ResultError
    {
        Code = 12223,
        Description = "An error occured while deleting the contact"
    };

    /// <summary>
    /// Gets the error occured while deleting.
    /// </summary>
    /// <value>
    /// The error occured while deleting.
    /// </value>
    public static ResultError ErrorOccuredWhileUpdating => new ResultError
    {
        Code = 12224,
        Description = "An error occured while updating the contact"
    };
}

