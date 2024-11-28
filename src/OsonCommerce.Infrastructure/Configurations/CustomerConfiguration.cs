using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OsonCommerce.Domain.Entities;

namespace OsonCommerce.Infrastructure.Configurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("customer");

        builder.Property(c => c.Id)
            .HasColumnType("UUID")
            .HasColumnName("id")
            .IsRequired();

        builder.Property(c => c.FirstName)
            .HasColumnType("VARCHAR")
            .HasColumnName("first_name")
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(c => c.LastName)
            .HasColumnType("VARCHAR")
            .HasColumnName("last_name")
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(c => c.Email)
            .HasColumnType("VARCHAR")
            .HasColumnName("email")
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(c => c.PhoneNumber)
            .HasColumnType("VARCHAR")
            .HasColumnName("phone_number")
            .HasMaxLength(15);

        builder.Property(c => c.ShippingAddress)
            .HasColumnType("VARCHAR")
            .HasColumnName("shipping_address")
            .HasMaxLength(200);
    }
}
