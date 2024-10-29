using CatalogService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("product");
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .HasColumnType("UUID")
            .HasColumnName("id")
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder.Property(p => p.Name)
            .HasColumnType("VARCHAR")
            .HasColumnName("name")
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(p => p.Unit)
            .HasColumnType("VARCHAR")
            .HasColumnName("unit")
            .IsRequired()
            .HasConversion<string>();

        builder.Property(p => p.ImageName)
            .HasColumnType("VARCHAR")
            .HasColumnName("image_name")
            .HasMaxLength(255);

        builder.Property(p => p.Description)
            .HasColumnType("VARCHAR")
            .HasColumnName("description")
            .HasMaxLength(500);

        builder.Property(p => p.Weight)
            .HasColumnType("DECIMAL")
            .HasColumnName("weight")
            .IsRequired();

        builder.Property(p => p.ManufactureDate)
            .HasColumnType("TIMESTAMP")
            .HasColumnName("manufacture_date")
            .IsRequired();

        builder.Property(p => p.ExpiryDate)
            .HasColumnType("TIMESTAMP")
            .HasColumnName("expiry_date");

        builder.Property(p => p.SKU)
            .HasColumnType("VARCHAR")
            .HasColumnName("sku")
            .HasMaxLength(50);

        builder.Property(p => p.UpdatedAt)
            .HasColumnType("TIMESTAMP")
            .HasColumnName("updated_at")
            .IsRequired();
    }
}
