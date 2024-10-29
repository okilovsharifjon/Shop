using CatalogService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogService.Infrastructure.Configurations
{
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.ToTable("brand");

            builder.HasKey(b => b.Id);

            builder.Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(b => b.Description)
                .HasMaxLength(500);

            builder.Property(b => b.LogoName)
                .HasMaxLength(100);

            builder.Property(b => b.WebsiteUrl)
                .HasMaxLength(200);

            builder.Property(b => b.CountryOfOrigin)
                .HasMaxLength(100);

            builder.Property(b => b.IsActive)
                .HasDefaultValue(true);

        }
    }
}
