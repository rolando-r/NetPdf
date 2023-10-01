using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
public class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.ToTable("person");

        builder.Property(x => x.Name)
        .HasMaxLength(100)
        .IsRequired();

        builder.Property(x => x.LastName)
        .HasMaxLength(200)
        .IsRequired();

        builder.Property(x => x.Age)
        .HasColumnType("date")
        .IsRequired();
    }
}