namespace Geraldapp.Persistence.Contexts;

using Microsoft.EntityFrameworkCore;

using Geraldapp.Domain.Entities;

/// <summary>
/// The Geraldapp context
/// </summary>
/// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
public class GeraldappContext : DbContext
{
    /// <summary>
    /// Gets or sets the billing document requests.
    /// </summary>
    /// <value>
    /// The billing document requests.
    /// </value>
    public virtual DbSet<Contact> Contacts { get; set; }

    /// <summary>
    /// Gets or sets the reservation request histories.
    /// </summary>
    /// <value>
    /// The reservation request histories.
    /// </value>
    public virtual DbSet<ContactAddress> ContactAddresses { get; set; }

    /// <summary>
    /// Gets or sets the skills.
    /// </summary>
    /// <value>
    /// The skills.
    /// </value>
    public virtual DbSet<Skill> Skills { get; set; }

    /// <summary>
    /// Gets or sets the contact skills.
    /// </summary>
    /// <value>
    /// The contact skills.
    /// </value>
    public virtual DbSet<ContactSkill> ContactSkills { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="GeraldappContext"/> class.
    /// </summary>
    /// <param name="options">The options.</param>
    public GeraldappContext(DbContextOptions<GeraldappContext> options)
    {
    }

    /// <summary>
    /// <para>
    /// Override this method to configure the database (and other options) to be used for this context.
    /// This method is called for each instance of the context that is created.
    /// The base implementation does nothing.
    /// </para>
    /// <para>
    /// In situations where an instance of <see cref="T:Microsoft.EntityFrameworkCore.DbContextOptions" /> may or may not have been passed
    /// to the constructor, you can use <see cref="P:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.IsConfigured" /> to determine if
    /// the options have already been set, and skip some or all of the logic in
    /// <see cref="M:Microsoft.EntityFrameworkCore.DbContext.OnConfiguring(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder)" />.
    /// </para>
    /// </summary>
    /// <param name="optionsBuilder">A builder used to create or modify options for this context. Databases (and other extensions)
    /// typically define extension methods on this object that allow you to configure the context.</param>
    /// <remarks>
    /// See <see href="https://aka.ms/efcore-docs-dbcontext">DbContext lifetime, configuration, and initialization</see>
    /// for more information.
    /// </remarks>
    protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase(databaseName: "Contacts");
    }

    /// <summary>
    /// Fluent API tables en column configuration.
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contact>().Ignore(t => t.Fullname);
        modelBuilder.Entity<Contact>(entity =>
        {
            entity.Property(e => e.FirstName)
                .HasMaxLength(40);

            entity.Property(e => e.LastName)
                .HasMaxLength(40);

            entity.Property(e => e.Email)
                .HasMaxLength(40);

            entity.Property(e => e.MobilePhoneNumber)
                .HasMaxLength(30);
        });

        modelBuilder.Entity<ContactAddress>(entity =>
        {
            entity.Property(e => e.Line1)
                .HasMaxLength(60);

            entity.Property(e => e.Line2)
                .HasMaxLength(60);

            entity.Property(e => e.City)
                .HasMaxLength(80);

            entity.Property(e => e.PostalCode)
                .HasMaxLength(10);
        });

        modelBuilder.Entity<ContactSkill>(entity =>
        {

        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.Property(e => e.Name)
                .HasMaxLength(60);
        });
    }
}