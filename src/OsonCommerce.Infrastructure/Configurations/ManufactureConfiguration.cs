using OsonCommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OsonCommerce.Infrastructure.Configurations;

public class ManufactureConfiguration : IEntityTypeConfiguration<Manufacture>
{
    public void Configure(EntityTypeBuilder<Manufacture> builder)
    {
        builder.ToTable("manufacture");

        builder.HasKey(b => b.Id);

        builder.Property(b => b.Id)
            .HasColumnType("UUID")
            .HasColumnName("id")
            .IsRequired();

        builder.Property(b => b.Name)
            .HasColumnType("VARCHAR")
            .HasColumnName("name")
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(b => b.Description)
            .HasColumnType("VARCHAR")
            .HasColumnName("description")
            .HasMaxLength(500);

        builder.Property(b => b.LogoName)
            .HasColumnType("VARCHAR")
            .HasColumnName("logo_name")
            .HasMaxLength(100);

        builder.Property(b => b.WebsiteUrl)
            .HasColumnType("VARCHAR")
            .HasColumnName("website_url")
            .HasMaxLength(200);

        builder.Property(b => b.CountryOfOrigin)
            .HasColumnType("VARCHAR")
            .HasColumnName("country_of_origin")
            .HasMaxLength(100);

        builder.Property(b => b.IsActive)
            .HasColumnType("BOOLEAN")
            .HasColumnName("is_active")
            .HasDefaultValue(true);

    }
}
