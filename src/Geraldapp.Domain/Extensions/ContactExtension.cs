namespace Geraldapp.Domain.Extensions;

using Geraldapp.Domain.Entities;

/// <summary>
/// The contact extension
/// </summary>
public static class ContactExtension
{
    /// <summary>
    /// Updates the specified data.
    /// </summary>
    /// <param name="contact">The contact.</param>
    /// <param name="data">The data.</param>
    public static void Update(this Contact contact, Contact data)
    {
        contact.FirstName = data.FirstName;
        contact.LastName = data.LastName;
        contact.Email = data.Email;
        contact.MobilePhoneNumber = data.MobilePhoneNumber;
        contact.Address.Line1 = data.Address.Line1;
        contact.Address.Line2 = data.Address.Line2;
        contact.Address.City = data.Address.City;
        contact.Address.PostalCode = data.Address.PostalCode;
    }
}

