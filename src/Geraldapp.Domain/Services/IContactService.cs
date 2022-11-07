namespace Geraldapp.Domain.Services;

using Geraldapp.Domain.Entities;
using Geraldapp.Domain.Models;

/// <summary>
/// The contact service
/// </summary>
public interface IContactService
{
    /// <summary>
    /// Gets the asynchronous.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns></returns>
    Task<Result<Contact>> GetAsync(Guid id);

    /// <summary>
    /// Creates the asynchronous.
    /// </summary>
    /// <param name="contact">The contact.</param>
    /// <returns></returns>
    Task<Result<Contact>> CreateAsync(Contact contact);

    /// <summary>
    /// Updates the asynchronous.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <param name="contact">The contact.</param>
    /// <returns></returns>
    Task<Result<Contact>> UpdateAsync(Guid id, Contact contact);

    /// <summary>
    /// Deletes the asynchronous.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns></returns>
    Task<Result> DeleteAsync(Guid id);
}