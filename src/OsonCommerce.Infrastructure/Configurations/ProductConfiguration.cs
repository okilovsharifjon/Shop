using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OsonCommerce.Domain.Entities;
namespace OsonCommerce.Infrastructure.Configurations
{
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
                .IsRequired(false);

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

            builder.Property(p => p.ManufactureId)
                .HasColumnType("UUID")
                .HasColumnName("manufacture_id");

            builder.Property(p => p.CategoryId)
                .HasColumnType("UUID")
                .HasColumnName("category_id");

            builder.Property(p => p.ProductAttributeId)
                .HasColumnType("UUID")
                .HasColumnName("product_attribute_id");

            builder.HasOne(p => p.Manufacture)
                .WithMany()
                .HasForeignKey(p => p.ManufactureId);

            builder.HasOne(p => p.ProductAttribute)
                .WithMany()
                .HasForeignKey(p => p.ProductAttributeId);

            builder.HasMany(p => p.ProductStocks)
                .WithOne()
                .HasForeignKey("ProductId");

            builder.HasMany(p => p.Categories)
                .WithMany("Products");

            builder.HasMany(p => p.ProductAttributes)
                .WithOne()
                .HasForeignKey("ProductId");

            builder.HasMany(p => p.ProductPrices)
                .WithOne()
                .HasForeignKey("ProductId");
        }
    }
}
