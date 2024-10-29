using CatalogService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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

        builder.Property(c => c.Price)
            .HasColumnType("DECIMAL")
            .HasColumnName("price")
            .IsRequired();

        builder.Property(c => c.IsAvailable)
            .HasColumnType("BOOLEAN")
            .HasColumnName("is_available")
            .IsRequired();

        builder.Property(c => c.LastUpdated)
            .HasColumnType("TIMESTAMP")
            .HasColumnName("last_updated")
            .IsRequired();
    }
}
