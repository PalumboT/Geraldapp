namespace Geraldapp.Application.Controllers;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

using Geraldapp.Application.DTOs;
using Geraldapp.Domain.Services;

/// <summary>
/// The contact skill controller
/// </summary>
/// <seealso cref="Geraldapp.Application.Controllers.ContactSkillControllerBase" />
public class ContactSkillController : ContactSkillControllerBase
{
    /// <summary>
    /// The logger
    /// </summary>
    private readonly ILogger<ContactSkillController> logger;

    /// <summary>
    /// The mapper
    /// </summary>
    private readonly IMapper mapper;

    /// <summary>
    /// The contact skill service
    /// </summary>
    private readonly IContactSkillService contactSkillService;

    /// <summary>
    /// Initializes a new instance of the <see cref="ContactSkillController"/> class.
    /// </summary>
    /// <param name="logger">The logger.</param>
    /// <param name="mapper">The mapper.</param>
    /// <param name="contactSkillService">The contact skill service.</param>
    public ContactSkillController(
        ILogger<ContactSkillController> logger,
        IMapper mapper,
        IContactSkillService contactSkillService)
    {
        this.logger = logger;
        this.mapper = mapper;
        this.contactSkillService = contactSkillService;
    }

    /// <summary>
    /// Get all skills of a contact by Id
    /// </summary>
    /// <param name="contactId">ID of contact</param>
    /// <returns>
    /// Successful operation
    /// </returns>
    /// <remarks>
    /// Returns all skills of a contact
    /// </remarks>
    public override async Task<ActionResult<ContactSkillsResponse>> GetContactSkillsByContactId([BindRequired, FromQuery] Guid contactId)
    {
        var result = await this.contactSkillService.GetAllByContactIdAsync(contactId);
        if (result.IsSuccess)
        {
            return Ok(new ContactSkillsResponse
            {
                IsSuccess = true,
                ContactSkills = this.mapper.Map<List<ContactSkill>>(result.Value)
            });
        }

        return BadRequest(new ContactSkillsResponse
        {
            IsSuccess = false,
            Errors = this.mapper.Map<List<Error>>(result.Errors)
        });
    }

    /// <summary>
    /// Find contact skill by ID
    /// </summary>
    /// <param name="id">ID of contact skill to return</param>
    /// <returns>
    /// Successful operation
    /// </returns>
    /// <remarks>
    /// Returns a single contact skill
    /// </remarks>
    public override async Task<ActionResult<ContactSkillResponse>> GetContactSkillById([BindRequired] Guid id)
    {
        var result = await this.contactSkillService.GetAsync(id);
        if (result.IsSuccess)
        {
            return Ok(new ContactSkillResponse
            {
                IsSuccess = true,
                ContactSkill = this.mapper.Map<ContactSkill>(result.Value)
            });
        }

        return BadRequest(new ContactSkillResponse
        {
            IsSuccess = false,
            Errors = this.mapper.Map<List<Error>>(result.Errors)
        });
    }

    /// <summary>
    /// Add a new contact skill
    /// </summary>
    /// <param name="body">Create a new contact skill</param>
    /// <returns>
    /// Successful operation
    /// </returns>
    /// <remarks>
    /// Add a new contact skill
    /// </remarks>
    public override async Task<ActionResult<ContactSkillResponse>> AddContactSkill([BindRequired, FromBody] CreateContactSkillRequest body)
    {
        var result = await this.contactSkillService.CreateAsync(this.mapper.Map<Domain.Entities.ContactSkill>(body));
        if (result.IsSuccess)
        {
            return Ok(new ContactSkillResponse
            {
                IsSuccess = true,
                ContactSkill = this.mapper.Map<ContactSkill>(result.Value)
            });
        }

        return BadRequest(new ContactSkillResponse
        {
            IsSuccess = false,
            Errors = this.mapper.Map<List<Error>>(result.Errors)
        });
    }

    /// <summary>
    /// Update an existing contact skill
    /// </summary>
    /// <param name="id">Contact skill id to update</param>
    /// <param name="body">Update an existent contact skill</param>
    /// <returns>
    /// Successful operation
    /// </returns>
    /// <remarks>
    /// Update an existing contact skill by Id
    /// </remarks>
    public override async Task<ActionResult<ContactSkillResponse>> UpdateContactSkill([BindRequired] Guid id, [BindRequired, FromBody] UpdateContactSkillRequest body)
    {
        var result = await this.contactSkillService.UpdateAsync(id, this.mapper.Map<Domain.Entities.ContactSkill>(body));
        if (result.IsSuccess)
        {
            return Ok(new ContactSkillResponse
            {
                IsSuccess = true,
                ContactSkill = this.mapper.Map<ContactSkill>(result.Value)
            });
        }

        return BadRequest(new ContactSkillResponse
        {
            IsSuccess = false,
            Errors = this.mapper.Map<List<Error>>(result.Errors)
        });
    }

    /// <summary>
    /// Deletes a contact skill
    /// </summary>
    /// <param name="id">Contact skill id to delete</param>
    /// <returns>
    /// Successful operation
    /// </returns>
    /// <remarks>
    /// delete a contact skill
    /// </remarks>
    public override async Task<ActionResult<BaseResponse>> DeleteContactSkill([BindRequired] Guid id)
    {
        var result = await this.contactSkillService.DeleteAsync(id);
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