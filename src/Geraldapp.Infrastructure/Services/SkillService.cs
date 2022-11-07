namespace Geraldapp.Infrastructure.Services;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Geraldapp.Domain.Entities;
using Geraldapp.Domain.Services;
using Geraldapp.Infrastructure.Errors;
using Geraldapp.Persistence.Contexts;
using Geraldapp.Domain.Models;

/// <summary>
/// The skill service
/// </summary>
/// <seealso cref="Geraldapp.Domain.Services.ISkillService" />
public class SkillService : ISkillService
{
    /// <summary>
    /// The logger
    /// </summary>
    private readonly ILogger<SkillService> logger;

    /// <summary>
    /// The mapper
    /// </summary>
    private readonly GeraldappContext contactContext;

    /// <summary>
    /// Initializes a new instance of the <see cref="SkillService"/> class.
    /// </summary>
    /// <param name="logger">The logger.</param>
    /// <param name="contactContext">The contact context.</param>
    public SkillService(
        ILogger<SkillService> logger,
        GeraldappContext contactContext)
    {
        this.logger = logger;
        this.contactContext = contactContext;
    }

    /// <summary>
    /// Gets all asynchronous.
    /// </summary>
    /// <returns></returns>
    public async Task<Result<IEnumerable<Skill>>> GetAllAsync()
    {
        List<Skill> skills;
        try
        {
            skills = await this.contactContext.Skills.ToListAsync();
        }
        catch (Exception exception)
        {
            this.logger.LogError(exception, "An error occured while getting all skills");
            return SkillError.ErrorOccuredWhileGettingAll;
        }

        return skills;
    }

    /// <summary>
    /// Gets the asynchronous.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns></returns>
    public async Task<Result<Skill>> GetAsync(Guid id)
    {
        Skill skill;
        try
        {
            skill = await this.contactContext.Skills.FirstOrDefaultAsync(s => s.Id == id);
        }
        catch (Exception exception)
        {
            this.logger.LogError(exception, "An error occured while getting the skill n°{id}", id);
            return SkillError.ErrorOccuredWhileGetting;
        }

        if (skill == null)
        {
            return SkillError.NotFound;
        }

        return skill;
    }
}