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
            builder.HasKey(pp => pp.ProductPriceID);

            builder.Property(pp => pp.ProductPriceID)
                .HasColumnType("UUID")
                .HasColumnName("id")
                .IsRequired();

            builder.Property(pp => pp.Price)
                .HasColumnType("DECIMAL")
                .HasColumnName("price")
                .IsRequired();

            builder.Property(pp => pp.ProductID)
                .HasColumnName("product_id")
                .IsRequired();

            builder.Property(pp => pp.StockID)
                .HasColumnName("warehouse_id")
                .IsRequired();

            builder.Property(pp => pp.PriceTypeID)
                .HasColumnName("price_type_id")
                .IsRequired();

            builder.HasOne(pp => pp.Product)
                .WithMany(p => p.ProductPrices)
                .HasForeignKey(pp => pp.ProductID);

            builder.HasOne(pp => pp.Stock)
                .WithMany()
                .HasForeignKey(pp => pp.StockID);

            builder.HasOne(pp => pp.PriceType)
                .WithMany()
                .HasForeignKey(pp => pp.PriceTypeID);
        }
    }
} 