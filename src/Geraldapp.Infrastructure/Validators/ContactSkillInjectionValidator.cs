namespace Geraldapp.Infrastructure.Validators;

using FluentValidation;
using Microsoft.EntityFrameworkCore;

using Geraldapp.Domain.Entities;
using Geraldapp.Infrastructure.Errors;
using Geraldapp.Persistence.Contexts;

/// <summary>
/// The contact skill injection validator
/// </summary>
/// <seealso cref="FluentValidation.AbstractValidator&lt;Geraldapp.Domain.Entities.ContactSkill&gt;" />
public class ContactSkillInjectionValidator : AbstractValidator<ContactSkill>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ContactSkillInjectionValidator"/> class.
    /// </summary>
    /// <param name="geraldappContext">The geraldapp context.</param>
    public ContactSkillInjectionValidator(GeraldappContext geraldappContext)
    {
        RuleFor(req => req)
            .MustAsync(async (req, _) => await geraldappContext.Contacts.AnyAsync(c => c.Id == req.ContactId))
            .WithErrorCode(ContactError.NotFound.Code.ToString())
            .WithMessage(ContactError.NotFound.Description)

            .MustAsync(async (req, _) => await geraldappContext.Skills.AnyAsync(c => c.Id == req.SkillId))
            .WithErrorCode(SkillError.NotFound.Code.ToString())
            .WithMessage(SkillError.NotFound.Description)

            .MustAsync(async (req, _) => !await geraldappContext.ContactSkills.AnyAsync(c => 
                c.SkillId == req.SkillId &&
                c.ContactId == req.ContactId))
            .WithErrorCode(ContactSkillError.HasAlreadyTheSkill.Code.ToString())
            .WithMessage(ContactSkillError.HasAlreadyTheSkill.Description);
    }
}
