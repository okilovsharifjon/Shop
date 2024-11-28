using OsonCommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OsonCommerce.Infrastructure.Configurations;

public class ProductAttributeConfiguration : IEntityTypeConfiguration<ProductAttribute>
{
    public void Configure(EntityTypeBuilder<ProductAttribute> builder)
    {
        builder.ToTable("product_attribute");
        builder.HasKey(pa => pa.ProductAttributeID);

        builder.Property(pa => pa.ProductAttributeID)
            .HasColumnType("UUID")
            .HasColumnName("id")
            .IsRequired();

        builder.Property(pa => pa.Name)
            .HasColumnType("VARCHAR")
            .HasColumnName("name")
            .IsRequired(false)
            .HasMaxLength(100);
    }
}
