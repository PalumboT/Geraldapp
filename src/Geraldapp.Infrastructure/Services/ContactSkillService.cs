namespace Geraldapp.Infrastructure.Services;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

using Geraldapp.Domain.Entities;
using Geraldapp.Domain.Extensions;
using Geraldapp.Domain.Models;
using Geraldapp.Domain.Services;
using Geraldapp.Infrastructure.Errors;
using Geraldapp.Infrastructure.Validators;
using Geraldapp.Persistence.Contexts;

/// <summary>
/// The contact skill service
/// </summary>
/// <seealso cref="Geraldapp.Domain.Services.IContactSkillService" />
public class ContactSkillService : IContactSkillService
{
    /// <summary>
    /// The logger
    /// </summary>
    private readonly ILogger<ContactSkillService> logger;

    /// <summary>
    /// The geraldapp context
    /// </summary>
    private readonly GeraldappContext geraldappContext;

    /// <summary>
    /// The contact skill injection validator
    /// </summary>
    private readonly ContactSkillInjectionValidator contactSkillInjectionValidator;

    /// <summary>
    /// Initializes a new instance of the <see cref="ContactSkillService"/> class.
    /// </summary>
    /// <param name="logger">The logger.</param>
    /// <param name="geraldappContext">The geraldapp context.</param>
    /// <param name="contactSkillInjectionValidator">The contact skill injection validator.</param>
    public ContactSkillService(
        ILogger<ContactSkillService> logger,
        GeraldappContext geraldappContext, 
        ContactSkillInjectionValidator contactSkillInjectionValidator)
    {
        this.logger = logger;
        this.geraldappContext = geraldappContext;
        this.contactSkillInjectionValidator = contactSkillInjectionValidator;
    }

    /// <summary>
    /// Gets the asynchronous.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns></returns>
    public async Task<Result<ContactSkill>> GetAsync(Guid id)
    {
        ContactSkill contact;
        try
        {
            contact = await this.geraldappContext.ContactSkills
                .FirstOrDefaultAsync(c => c.Id == id);
        }
        catch (Exception exception)
        {
            this.logger.LogError(exception, "An error occured while getting the contact skill n°{id}", id);
            return ContactSkillError.ErrorOccuredWhileGetting;
        }

        if (contact == null)
        {
            return ContactSkillError.NotFound;
        }

        return contact;
    }


    /// <summary>
    /// Gets all by contact identifier asynchronous.
    /// </summary>
    /// <param name="contactId">The contact identifier.</param>
    /// <returns></returns>
    public async Task<Result<IList<ContactSkill>>> GetAllByContactIdAsync(Guid contactId)
    {
        List<ContactSkill> contactSkills;
        try
        {
            contactSkills = await this.geraldappContext.ContactSkills
                .Where(c => c.ContactId == contactId)
                .ToListAsync();
        }
        catch (Exception exception)
        {
            this.logger.LogError(exception, "An error occured while getting the contact skill for contact n°{id}", contactId);
            return ContactSkillError.ErrorOccuredWhileGetting;
        }

        return contactSkills;
    }

    /// <summary>
    /// Creates the asynchronous.
    /// </summary>
    /// <param name="contactSkill">The contact skill.</param>
    /// <returns></returns>
    public async Task<Result<ContactSkill>> CreateAsync(ContactSkill contactSkill)
    {
        var contactSkillValidationResult = await this.contactSkillInjectionValidator.ValidateAsync(contactSkill);
        if (!contactSkillValidationResult.IsValid)
        {
            return contactSkillValidationResult.Errors;
        }

        try
        {
            await this.geraldappContext.AddAsync(contactSkill);
            await this.geraldappContext.SaveChangesAsync();
        }
        catch (Exception exception)
        {
            this.logger.LogError(exception, "An error occured while creation a contact skill");
            return ContactSkillError.ErrorOccuredWhileCreating;
        }

        return contactSkill;
    }

    /// <summary>
    /// Updates the asynchronous.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <param name="contactSkill">The contact skill.</param>
    /// <returns></returns>
    public async Task<Result<ContactSkill>> UpdateAsync(Guid id, ContactSkill contactSkill)
    {
        var getExistingContactSkillResult = await this.GetAsync(id);
        if (!getExistingContactSkillResult.IsSuccess)
        {
            return getExistingContactSkillResult;
        }

        getExistingContactSkillResult.Value.Update(contactSkill);

        try
        {
            this.geraldappContext.ContactSkills.Update(getExistingContactSkillResult.Value);
            await this.geraldappContext.SaveChangesAsync();
        }
        catch (Exception exception)
        {
            this.logger.LogError(exception, "An error occured while updating the contact skill n°{id}", id);
            return ContactSkillError.ErrorOccuredWhileUpdating;
        }

        return getExistingContactSkillResult.Value;
    }

    /// <summary>
    /// Deletes the asynchronous.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns></returns>
    public async Task<Result> DeleteAsync(Guid id)
    {
        var getExistingContactSkillResult = await this.GetAsync(id);
        if (!getExistingContactSkillResult.IsSuccess)
        {
            return Result.Error(getExistingContactSkillResult.Errors);
        }

        try
        {
            this.geraldappContext.ContactSkills.Remove(getExistingContactSkillResult.Value);
            await this.geraldappContext.SaveChangesAsync();
        }
        catch (Exception exception)
        {
            this.logger.LogError(exception, "An error occured while deleting the contact skill n°{id}", id);
            return ContactSkillError.ErrorOccuredWhileDeleting;
        }

        return Result.Success();
    }
}

