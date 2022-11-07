namespace Geraldapp.Domain.Entities;

using System;

/// <summary>
/// The contact
/// </summary>
public class Contact
{
    /// <summary>
    /// Gets or sets the identifier.
    /// </summary>
    /// <value>
    /// The identifier.
    /// </value>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the address identifier.
    /// </summary>
    /// <value>
    /// The address identifier.
    /// </value>
    public Guid AddressId { get; set; }

    /// <summary>
    /// Gets or sets the first name.
    /// </summary>
    /// <value>
    /// The first name.
    /// </value>
    public string FirstName { get; set; }

    /// <summary>
    /// Gets or sets the last name.
    /// </summary>
    /// <value>
    /// The last name.
    /// </value>
    public string LastName { get; set; }

    /// <summary>
    /// Gets or sets the fullname.
    /// </summary>
    /// <value>
    /// The fullname.
    /// </value>
    public string Fullname => $"{this.FirstName} {this.LastName}";

    /// <summary>
    /// Gets or sets the email.
    /// </summary>
    /// <value>
    /// The email.
    /// </value>
    public string Email { get; set; }

    /// <summary>
    /// Gets or sets the mobile phone number.
    /// </summary>
    /// <value>
    /// The mobile phone number.
    /// </value>
    public string MobilePhoneNumber { get; set; }

    /// <summary>
    /// Gets or sets the address.
    /// </summary>
    /// <value>
    /// The address.
    /// </value>
    public virtual ContactAddress Address { get; set; }
}
