using OsonCommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OsonCommerce.Infrastructure.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("user");

        builder.Property(e => e.Id)
            .HasColumnType("UUID")
            .HasColumnName("id")
            .IsRequired();

        builder.Property(e => e.FirstName)
            .HasColumnType("VARCHAR")
            .HasColumnName("first_name")
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(e => e.LastName)
            .HasColumnType("VARCHAR")
            .HasColumnName("last_name")
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(e => e.Email)
            .HasColumnType("VARCHAR")
            .HasColumnName("email")
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(e => e.PhoneNumber)
            .HasColumnType("VARCHAR")
            .HasColumnName("phone_number")
            .HasMaxLength(15);

        builder.Property(e => e.Password)
            .HasColumnType("TEXT")
            .HasColumnName("password")
            .IsRequired();
    }
}
