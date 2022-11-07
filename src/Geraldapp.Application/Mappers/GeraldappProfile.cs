namespace Geraldapp.Application.Mappers;

using AutoMapper;

using Geraldapp.Domain.Entities;
using Geraldapp.Domain.Models;

/// <summary>
/// The Geraldapp profile
/// </summary>
/// <seealso cref="AutoMapper.Profile" />
public class GeraldappProfile : Profile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GeraldappProfile"/> class.
    /// </summary>
    public GeraldappProfile()
    {
        this.CreateMap<DTOs.Contact, Contact>().ReverseMap();
        this.CreateMap<DTOs.Address, ContactAddress>().ReverseMap();
        this.CreateMap<DTOs.CreateContactRequest, Contact>().ReverseMap();
        this.CreateMap<DTOs.UpdateContactRequest, Contact>().ReverseMap();

        this.CreateMap<DTOs.Skill, Skill>().ReverseMap();
        this.CreateMap<DTOs.ContactSkill, ContactSkill>().ReverseMap();
        this.CreateMap<DTOs.SkillLevel, SkillLevel>().ReverseMap();
        this.CreateMap<DTOs.CreateContactSkillRequest, ContactSkill>().ReverseMap();
        this.CreateMap<DTOs.UpdateContactSkillRequest, ContactSkill>().ReverseMap();

        this.CreateMap<DTOs.Error, ResultError>().ReverseMap();
    }
}
