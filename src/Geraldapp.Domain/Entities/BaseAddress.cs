namespace Geraldapp.Domain.Entities;

/// <summary>
/// The base address entity
/// </summary>
public abstract class BaseAddress
{
    /// <summary>
    /// Gets or sets the identifier.
    /// </summary>
    /// <value>
    /// The identifier.
    /// </value>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the line1.
    /// </summary>
    /// <value>
    /// The line1.
    /// </value>
    public string Line1 { get; set; }

    /// <summary>
    /// Gets or sets the line2.
    /// </summary>
    /// <value>
    /// The line2.
    /// </value>
    public string Line2 { get; set; }

    /// <summary>
    /// Gets or sets the postal code.
    /// </summary>
    /// <value>
    /// The postal code.
    /// </value>
    public string PostalCode { get; set; }

    /// <summary>
    /// Gets or sets the city.
    /// </summary>
    /// <value>
    /// The city.
    /// </value>
    public string City { get; set; }
}
