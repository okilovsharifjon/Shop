using OsonCommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OsonCommerce.Infrastructure.Configurations;

public class PriceTypeConfiguration : IEntityTypeConfiguration<PriceType>
{
    public void Configure(EntityTypeBuilder<PriceType> builder)
    {
        builder.ToTable("price_type");
        builder.HasKey(pt => pt.PriceTypeID);

        builder.Property(pt => pt.PriceTypeID)
            .HasColumnName("price_type_id")
            .IsRequired();

        builder.Property(pt => pt.Name)
            .HasColumnType("VARCHAR")
            .HasColumnName("name")
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(pt => pt.Description)
            .HasColumnType("VARCHAR")
            .HasColumnName("description")
            .HasMaxLength(500);

        builder.HasMany(pt => pt.ProductPrices)
            .WithOne(pp => pp.PriceType)
            .HasForeignKey(pp => pp.PriceTypeID);
    }
}
