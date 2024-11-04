using OsonCommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OsonCommerce.Infrastructure.Configurations
{
    public class ProductInStockConfiguration : IEntityTypeConfiguration<ProductInStock>
    {
        public void Configure(EntityTypeBuilder<ProductInStock> builder)
        {
            builder.ToTable("product_in_stock");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnType("UUID")
                .HasColumnName("id")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(c => c.ProductId)
                .HasColumnType("UUID")
                .HasColumnName("product_id")
                .IsRequired();

            builder.Property(c => c.StockId)
                .HasColumnType("UUID")
                .HasColumnName("stock_id")
                .IsRequired();

            builder.Property(c => c.ProviderId)
                .HasColumnType("UUID")
                .HasColumnName("provider_id")
                .IsRequired();

            builder.Property(c => c.Quantity)
                .HasColumnType("INTEGER")
                .HasColumnName("quantity")
                .IsRequired();

            builder.Property(c => c.IsAvailable)
                .HasColumnType("BOOLEAN")
                .HasColumnName("is_available")
                .IsRequired();

            builder.Property(c => c.LastUpdated)
                .HasColumnType("TIMESTAMP")
                .HasColumnName("last_updated")
                .IsRequired();

            builder.Property(c => c.ProductPriceId)
                .HasColumnType("UUID")
                .HasColumnName("product_price_id")
                .IsRequired();

            builder.HasOne(c => c.ProductPrice)
                .WithMany()
                .HasForeignKey(c => c.ProductPriceId);

            builder.HasOne(c => c.Stock)
                .WithMany()
                .HasForeignKey(c => c.StockId);

            builder.HasOne(c => c.Provider)
                .WithMany()
                .HasForeignKey(c => c.ProviderId);

            builder.HasOne(c => c.Product)
                .WithMany()
                .HasForeignKey(c => c.ProductId);
        }
    }
}
