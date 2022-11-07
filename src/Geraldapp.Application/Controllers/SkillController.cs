namespace Geraldapp.Application.Controllers;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

using Geraldapp.Application.DTOs;
using Geraldapp.Domain.Services;

/// <summary>
/// The skill controller
/// </summary>
/// <seealso cref="Geraldapp.Application.Controllers.SkillControllerBase" />
public class SkillController : SkillControllerBase
{
    /// <summary>
    /// The logger
    /// </summary>
    private readonly ILogger<SkillController> logger;

    /// <summary>
    /// The mapper
    /// </summary>
    private readonly IMapper mapper;

    /// <summary>
    /// The contact service
    /// </summary>
    private readonly ISkillService skillService;

    /// <summary>
    /// Initializes a new instance of the <see cref="SkillController"/> class.
    /// </summary>
    /// <param name="logger">The logger.</param>
    /// <param name="mapper">The mapper.</param>
    /// <param name="skillService">The skill service.</param>
    public SkillController(
        ILogger<SkillController> logger,
        IMapper mapper,
        ISkillService skillService)
    {
        this.logger = logger;
        this.mapper = mapper;
        this.skillService = skillService;
    }

    /// <summary>
    /// Get all skills
    /// </summary>
    /// <returns>
    /// Successful operation
    /// </returns>
    /// <remarks>
    /// Returns all skills
    /// </remarks>
    public override async Task<ActionResult<SkillsResponse>> GetAllSkills()
    {
        var result = await this.skillService.GetAllAsync();
        if (result.IsSuccess)
        {
            return Ok(new SkillsResponse
            {
                IsSuccess = true,
                Skills = this.mapper.Map<List<Skill>>(result.Value)
            });
        }

        return BadRequest(new SkillsResponse
        {
            IsSuccess = false,
            Errors = this.mapper.Map<List<Error>>(result.Errors)
        });
    }
}