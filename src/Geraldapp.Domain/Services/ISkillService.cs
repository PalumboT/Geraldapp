namespace Geraldapp.Domain.Services;

using Geraldapp.Domain.Entities;
using Geraldapp.Domain.Models;

/// <summary>
/// The skill service
/// </summary>
public interface ISkillService
{
    /// <summary>
    /// Gets all asynchronous.
    /// </summary>
    /// <returns></returns>
    Task<Result<IEnumerable<Skill>>> GetAllAsync();

    /// <summary>
    /// Gets the asynchronous.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns></returns>
    Task<Result<Skill>> GetAsync(Guid id);
}