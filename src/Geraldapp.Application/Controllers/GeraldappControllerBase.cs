//----------------------
// <auto-generated>
//     Generated using the NSwag toolchain v13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0)) (http://NSwag.org)
// </auto-generated>
//----------------------

using Geraldapp.Application.DTOs;

#pragma warning disable 108 // Disable "CS0108 '{derivedDto}.ToJson()' hides inherited member '{dtoBase}.ToJson()'. Use the new keyword if hiding was intended."
#pragma warning disable 114 // Disable "CS0114 '{derivedDto}.RaisePropertyChanged(String)' hides inherited member 'dtoBase.RaisePropertyChanged(String)'. To make the current member override that implementation, add the override keyword. Otherwise add the new keyword."
#pragma warning disable 472 // Disable "CS0472 The result of the expression is always 'false' since a value of type 'Int32' is never equal to 'null' of type 'Int32?'
#pragma warning disable 1573 // Disable "CS1573 Parameter '...' has no matching param tag in the XML comment for ...
#pragma warning disable 1591 // Disable "CS1591 Missing XML comment for publicly visible type or member ..."
#pragma warning disable 8073 // Disable "CS8073 The result of the expression is always 'false' since a value of type 'T' is never equal to 'null' of type 'T?'"
#pragma warning disable 3016 // Disable "CS3016 Arrays as attribute arguments is not CLS-compliant"
#pragma warning disable 8603 // Disable "CS8603 Possible null reference return"

namespace Geraldapp.Application.Controllers
{
    using System = global::System;

    [System.CodeDom.Compiler.GeneratedCode("NSwag", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
    [Microsoft.AspNetCore.Mvc.Route("api/v3")]

    public abstract class SkillControllerBase : Microsoft.AspNetCore.Mvc.Controller
    {
        /// <summary>
        /// Get all skills
        /// </summary>
        /// <remarks>
        /// Returns all skills
        /// </remarks>
        /// <returns>Successful operation</returns>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("skill")]
        public abstract System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.ActionResult<SkillsResponse>> GetAllSkills();

    }

    [System.CodeDom.Compiler.GeneratedCode("NSwag", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
    [Microsoft.AspNetCore.Mvc.Route("api/v3")]

    public abstract class ContactSkillControllerBase : Microsoft.AspNetCore.Mvc.Controller
    {
        /// <summary>
        /// Get all skills of a contact by Id
        /// </summary>
        /// <remarks>
        /// Returns all skills of a contact
        /// </remarks>
        /// <param name="contactId">ID of contact</param>
        /// <returns>Successful operation</returns>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("contact-skill/getByContactId")]
        public abstract System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.ActionResult<ContactSkillsResponse>> GetContactSkillsByContactId([Microsoft.AspNetCore.Mvc.FromQuery] [Microsoft.AspNetCore.Mvc.ModelBinding.BindRequired] System.Guid contactId);

        /// <summary>
        /// Add a new contact skill
        /// </summary>
        /// <remarks>
        /// Add a new contact skill
        /// </remarks>
        /// <param name="body">Create a new contact skill</param>
        /// <returns>Successful operation</returns>
        [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("contact-skill")]
        public abstract System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.ActionResult<ContactSkillResponse>> AddContactSkill([Microsoft.AspNetCore.Mvc.FromBody] [Microsoft.AspNetCore.Mvc.ModelBinding.BindRequired] CreateContactSkillRequest body);

        /// <summary>
        /// Find contact skill by ID
        /// </summary>
        /// <remarks>
        /// Returns a single contact skill
        /// </remarks>
        /// <param name="id">ID of contact skill to return</param>
        /// <returns>Successful operation</returns>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("contact-skill/{id}")]
        public abstract System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.ActionResult<ContactSkillResponse>> GetContactSkillById([Microsoft.AspNetCore.Mvc.ModelBinding.BindRequired] System.Guid id);

        /// <summary>
        /// Update an existing contact skill
        /// </summary>
        /// <remarks>
        /// Update an existing contact skill by Id
        /// </remarks>
        /// <param name="id">Contact skill id to update</param>
        /// <param name="body">Update an existent contact skill</param>
        /// <returns>Successful operation</returns>
        [Microsoft.AspNetCore.Mvc.HttpPut, Microsoft.AspNetCore.Mvc.Route("contact-skill/{id}")]
        public abstract System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.ActionResult<ContactSkillResponse>> UpdateContactSkill([Microsoft.AspNetCore.Mvc.ModelBinding.BindRequired] System.Guid id, [Microsoft.AspNetCore.Mvc.FromBody] [Microsoft.AspNetCore.Mvc.ModelBinding.BindRequired] UpdateContactSkillRequest body);

        /// <summary>
        /// Deletes a contact skill
        /// </summary>
        /// <remarks>
        /// delete a contact skill
        /// </remarks>
        /// <param name="id">Contact skill id to delete</param>
        /// <returns>Successful operation</returns>
        [Microsoft.AspNetCore.Mvc.HttpDelete, Microsoft.AspNetCore.Mvc.Route("contact-skill/{id}")]
        public abstract System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.ActionResult<BaseResponse>> DeleteContactSkill([Microsoft.AspNetCore.Mvc.ModelBinding.BindRequired] System.Guid id);

    }

    [System.CodeDom.Compiler.GeneratedCode("NSwag", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
    [Microsoft.AspNetCore.Mvc.Route("api/v3")]

    public abstract class ContactControllerBase : Microsoft.AspNetCore.Mvc.Controller
    {
        /// <summary>
        /// Find contact by ID
        /// </summary>
        /// <remarks>
        /// Returns a single contact
        /// </remarks>
        /// <param name="id">ID of contact to return</param>
        /// <returns>Successful operation</returns>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("contact/{id}")]
        public abstract System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.ActionResult<ContactResponse>> GetContactById([Microsoft.AspNetCore.Mvc.ModelBinding.BindRequired] System.Guid id);

        /// <summary>
        /// Update an existing contact
        /// </summary>
        /// <remarks>
        /// Update an existing contact by Id
        /// </remarks>
        /// <param name="id">Contact id to update</param>
        /// <param name="body">Update an existent contact</param>
        /// <returns>Successful operation</returns>
        [Microsoft.AspNetCore.Mvc.HttpPut, Microsoft.AspNetCore.Mvc.Route("contact/{id}")]
        public abstract System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.ActionResult<ContactResponse>> UpdateContactById([Microsoft.AspNetCore.Mvc.ModelBinding.BindRequired] System.Guid id, [Microsoft.AspNetCore.Mvc.FromBody] [Microsoft.AspNetCore.Mvc.ModelBinding.BindRequired] UpdateContactRequest body);

        /// <summary>
        /// Deletes a contact
        /// </summary>
        /// <remarks>
        /// delete a contact
        /// </remarks>
        /// <param name="id">Contact id to delete</param>
        /// <returns>Successful operation</returns>
        [Microsoft.AspNetCore.Mvc.HttpDelete, Microsoft.AspNetCore.Mvc.Route("contact/{id}")]
        public abstract System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.ActionResult<BaseResponse>> DeleteContactbyId([Microsoft.AspNetCore.Mvc.ModelBinding.BindRequired] System.Guid id);

        /// <summary>
        /// Add a new contact
        /// </summary>
        /// <remarks>
        /// Add a new contact
        /// </remarks>
        /// <param name="body">Create a new contact</param>
        /// <returns>Successful operation</returns>
        [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("contact")]
        public abstract System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.ActionResult<ContactResponse>> AddContact([Microsoft.AspNetCore.Mvc.FromBody] [Microsoft.AspNetCore.Mvc.ModelBinding.BindRequired] CreateContactRequest body);

    }

    


}

#pragma warning restore 1591
#pragma warning restore 1573
#pragma warning restore  472
#pragma warning restore  114
#pragma warning restore  108
#pragma warning restore 3016
#pragma warning restore 8603