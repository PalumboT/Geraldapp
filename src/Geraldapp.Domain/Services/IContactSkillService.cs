namespace Geraldapp.Domain.Services;

using Geraldapp.Domain.Entities;
using Geraldapp.Domain.Models;

/// <summary>
/// The contact skill service
/// </summary>
public interface IContactSkillService
{
    /// <summary>
    /// Gets the asynchronous.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns></returns>
    Task<Result<ContactSkill>> GetAsync(Guid id);

    /// <summary>
    /// Gets all by contact identifier asynchronous.
    /// </summary>
    /// <param name="contactId">The contact identifier.</param>
    /// <returns></returns>
    Task<Result<IList<ContactSkill>>> GetAllByContactIdAsync(Guid contactId);

    /// <summary>
    /// Creates the asynchronous.
    /// </summary>
    /// <param name="contact">The contact.</param>
    /// <returns></returns>
    Task<Result<ContactSkill>> CreateAsync(ContactSkill contact);

    /// <summary>
    /// Updates the asynchronous.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <param name="contact">The contact.</param>
    /// <returns></returns>
    Task<Result<ContactSkill>> UpdateAsync(Guid id, ContactSkill contact);

    /// <summary>
    /// Deletes the asynchronous.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns></returns>
    Task<Result> DeleteAsync(Guid id);
}