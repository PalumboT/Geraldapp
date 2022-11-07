namespace Geraldapp.Infrastructure.Services;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

using Geraldapp.Domain.Entities;
using Geraldapp.Domain.Extensions;
using Geraldapp.Domain.Services;
using Geraldapp.Infrastructure.Errors;
using Geraldapp.Persistence.Contexts;
using Geraldapp.Domain.Models;

/// <summary>
/// The contact service
/// </summary>
/// <seealso cref="Geraldapp.Domain.Services.IContactService" />
public class ContactService : IContactService
{
    /// <summary>
    /// The logger
    /// </summary>
    private readonly ILogger<ContactService> logger;

    /// <summary>
    /// The geraldapp context
    /// </summary>
    private readonly GeraldappContext geraldappContext;

    /// <summary>
    /// Initializes a new instance of the <see cref="ContactService"/> class.
    /// </summary>
    /// <param name="logger">The logger.</param>
    /// <param name="geraldappContext">The geraldapp context.</param>
    public ContactService(
        ILogger<ContactService> logger,
        GeraldappContext geraldappContext)
    {
        this.logger = logger;
        this.geraldappContext = geraldappContext;
    }

    /// <summary>
    /// Gets the asynchronous.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns></returns>
    public async Task<Result<Contact>> GetAsync(Guid id)
    {
        Contact contact;
        try
        {
            contact = await this.geraldappContext.Contacts
                .Include(c => c.Address)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
        catch (Exception exception)
        {
            this.logger.LogError(exception, "An error occured while getting the contact n°{id}", id);
            return ContactError.ErrorOccuredWhileGetting;
        }

        if (contact == null)
        {
            return ContactError.NotFound;
        }

        return contact;
    }

    /// <summary>
    /// Creates the asynchronous.
    /// </summary>
    /// <param name="contact">The contact.</param>
    /// <returns></returns>
    public async Task<Result<Contact>> CreateAsync(Contact contact)
    {
        try
        {
            await this.geraldappContext.AddAsync(contact);
            await this.geraldappContext.SaveChangesAsync();
        }
        catch (Exception exception)
        {
            this.logger.LogError(exception, "An error occured while creation a contact");
            return ContactError.ErrorOccuredWhileCreating;
        }

        return contact;
    }

    /// <summary>
    /// Updates the asynchronous.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <param name="contact">The contact.</param>
    /// <returns></returns>
    public async Task<Result<Contact>> UpdateAsync(Guid id, Contact contact)
    {
        var getExistingContactResult = await this.GetAsync(id);
        if (!getExistingContactResult.IsSuccess)
        {
            return getExistingContactResult;
        }

        getExistingContactResult.Value.Update(contact);

        try
        {
            this.geraldappContext.Contacts.Update(getExistingContactResult.Value);
            await this.geraldappContext.SaveChangesAsync();
        }
        catch (Exception exception)
        {
            this.logger.LogError(exception, "An error occured while updating the contact n°{id}", id);
            return ContactError.ErrorOccuredWhileUpdating;
        }

        return getExistingContactResult.Value;
    }

    /// <summary>
    /// Deletes the asynchronous.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns></returns>
    public async Task<Result> DeleteAsync(Guid id)
    {
        Contact contact;
        try
        {
            contact = await this.geraldappContext.Contacts
                .FirstOrDefaultAsync(c => c.Id == id);
        }
        catch (Exception exception)
        {
            this.logger.LogError(exception, "An error occured while getting the contact n°{id}", id);
            return ContactError.ErrorOccuredWhileGetting;
        }

        if (contact == null)
        {
            return ContactError.NotFound;
        }

        try
        {
            this.geraldappContext.Contacts.Remove(contact);
            await this.geraldappContext.SaveChangesAsync();
        }
        catch (Exception exception)
        {
            this.logger.LogError(exception, "An error occured while deleting the contact n°{id}", id);
            return ContactError.ErrorOccuredWhileDeleting;
        }

        return Result.Success();
    }
}