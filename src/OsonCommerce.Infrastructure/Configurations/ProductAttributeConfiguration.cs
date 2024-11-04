using OsonCommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OsonCommerce.Infrastructure.Configurations
{
    public class ProductAttributeConfiguration : IEntityTypeConfiguration<ProductAttribute>
    {
        public void Configure(EntityTypeBuilder<ProductAttribute> builder)
        {
            builder.ToTable("product_attribute");
            builder.HasKey(pa => pa.ProductAttributeID);

            builder.Property(pa => pa.ProductAttributeID)
                .HasColumnType("UUID")
                .HasColumnName("id")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(pa => pa.Name)
                .HasColumnType("VARCHAR")
                .HasColumnName("name")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(pa => pa.Color)
                .HasColumnType("VARCHAR")
                .HasColumnName("color")
                .IsRequired(false)
                .HasMaxLength(100);

            builder.Property(pa => pa.Memory)
                .HasColumnType("VARCHAR")
                .HasColumnName("memory")
                .IsRequired(false)
                .HasMaxLength(100);

            builder.Property(pa => pa.Ram)
                .HasColumnType("VARCHAR")
                .HasColumnName("ram")
                .IsRequired(false)
                .HasMaxLength(100);
        }
    }
} 