namespace Geraldapp.Application.Controllers;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

using Geraldapp.Application.DTOs;
using Geraldapp.Domain.Services;

/// <summary>
/// The contact controller
/// </summary>
/// <seealso cref="Geraldapp.Application.Controllers.ContactControllerBase" />
public class ContactController : ContactControllerBase
{
    /// <summary>
    /// The logger
    /// </summary>
    private readonly ILogger<ContactController> logger;

    /// <summary>
    /// The mapper
    /// </summary>
    private readonly IMapper mapper;

    /// <summary>
    /// The contact service
    /// </summary>
    private readonly IContactService contactService;

    /// <summary>
    /// Initializes a new instance of the <see cref="ContactController"/> class.
    /// </summary>
    /// <param name="logger">The logger.</param>
    /// <param name="contactService">The contact service.</param>
    public ContactController(
        ILogger<ContactController> logger, 
        IMapper mapper,
        IContactService contactService)
    {
        this.logger = logger;
        this.mapper = mapper;
        this.contactService = contactService;
    }

    /// <summary>
    /// Find contact by ID
    /// </summary>
    /// <param name="id">ID of contact to return</param>
    /// <returns>
    /// Successful operation
    /// </returns>
    /// <remarks>
    /// Returns a single contact
    /// </remarks>
    public override async Task<ActionResult<ContactResponse>> GetContactById([BindRequired] Guid id)
    {
        var result = await this.contactService.GetAsync(id);
        if (result.IsSuccess)
        {
            return Ok(new ContactResponse
            {
                IsSuccess = true,
                Contact = this.mapper.Map<Contact>(result.Value)
            });
        }

        return BadRequest(new ContactResponse
        {
            IsSuccess = false,
            Errors = this.mapper.Map<List<Error>>(result.Errors)
        });
    }

    /// <summary>
    /// Add a new contact
    /// </summary>
    /// <param name="body">Create a new contact</param>
    /// <returns>
    /// Successful operation
    /// </returns>
    /// <remarks>
    /// Add a new contact
    /// </remarks>
    public override async Task<ActionResult<ContactResponse>> AddContact([BindRequired, FromBody] CreateContactRequest body)
    {
        var result = await this.contactService.CreateAsync(this.mapper.Map<Domain.Entities.Contact>(body));
        if (result.IsSuccess)
        {
            return Ok(new ContactResponse
            {
                IsSuccess = true,
                Contact = this.mapper.Map<Contact>(result.Value)
            });
        }

        return BadRequest(new ContactResponse
        {
            IsSuccess = false,
            Errors = this.mapper.Map<List<Error>>(result.Errors)
        });
    }

    /// <summary>
    /// Update an existing contact
    /// </summary>
    /// <param name="id">Contact id to update</param>
    /// <param name="body">Update an existent contact</param>
    /// <returns>
    /// Successful operation
    /// </returns>
    /// <remarks>
    /// Update an existing contact by Id
    /// </remarks>
    public override async Task<ActionResult<ContactResponse>> UpdateContactById([BindRequired] Guid id, [FromBody][BindRequired] UpdateContactRequest body)
    {
        var result = await this.contactService.UpdateAsync(id, this.mapper.Map<Domain.Entities.Contact>(body));
        if (result.IsSuccess)
        {
            return Ok(new ContactResponse
            {
                IsSuccess = true,
                Contact = this.mapper.Map<Contact>(result.Value)
            });
        }

        return BadRequest(new ContactResponse
        {
            IsSuccess = false,
            Errors = this.mapper.Map<List<Error>>(result.Errors)
        });
    }

    /// <summary>
    /// Deletes a contact
    /// </summary>
    /// <param name="id">Contact id to delete</param>
    /// <returns>
    /// Successful operation
    /// </returns>
    /// <remarks>
    /// delete a contact
    /// </remarks>
    public override async Task<ActionResult<BaseResponse>> DeleteContactbyId([BindRequired] Guid id)
    {
        var result = await this.contactService.DeleteAsync(id);
        if (result.IsSuccess)
        {
            return Ok(new BaseResponse
            {
                IsSuccess = true,
            });
        }

        return BadRequest(new BaseResponse
        {
            IsSuccess = false,
            Errors = this.mapper.Map<List<Error>>(result.Errors)
        });
    }
}