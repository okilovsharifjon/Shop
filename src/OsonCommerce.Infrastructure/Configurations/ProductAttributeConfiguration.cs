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
            builder.HasKey(pa => pa.Id);

            builder.Property(pa => pa.Id)
                .HasColumnType("UUID")
                .HasColumnName("id")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(pa => pa.Name)
                .HasColumnType("VARCHAR")
                .HasColumnName("name")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(pa => pa.Value)
                .HasColumnType("VARCHAR")
                .HasColumnName("value")
                .IsRequired()
                .HasMaxLength(100);
        }
    }
} 