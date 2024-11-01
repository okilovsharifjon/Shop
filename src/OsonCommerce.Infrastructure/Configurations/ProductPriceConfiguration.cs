using OsonCommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OsonCommerce.Infrastructure.Configurations
{
    public class ProductPriceConfiguration : IEntityTypeConfiguration<ProductPrice>
    {
        public void Configure(EntityTypeBuilder<ProductPrice> builder)
        {
            builder.ToTable("product_price");
            builder.HasKey(pp => pp.Id);

            builder.Property(pp => pp.Id)
                .HasColumnType("UUID")
                .HasColumnName("id")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(pp => pp.Price)
                .HasColumnType("DECIMAL")
                .HasColumnName("price")
                .IsRequired();

            builder.Property(pp => pp.Currency)
                .HasColumnType("VARCHAR")
                .HasColumnName("currency")
                .IsRequired()
                .HasMaxLength(3);

            builder.Property(pp => pp.EffectiveDate)
                .HasColumnType("TIMESTAMP")
                .HasColumnName("effective_date")
                .IsRequired();
        }
    }
} 