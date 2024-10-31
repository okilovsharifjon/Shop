using OsonCommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OsonCommerce.Infrastructure.Configurations
{
    public class CashboxConfiguration : IEntityTypeConfiguration<Cashbox>
    {
    public void Configure(EntityTypeBuilder<Cashbox> builder)
    {
        builder.ToTable("cashbox");
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .HasColumnType("UUID")
            .HasColumnName("id")
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder.Property(c => c.Name)
            .HasColumnType("VARCHAR")
            .HasColumnName("name")
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(c => c.Key)
            .HasColumnType("VARCHAR")
            .HasColumnName("key")
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(c => c.Balance)
            .HasColumnType("DECIMAL")
            .HasColumnName("balance")
            .IsRequired();

        builder.Property(c => c.IsActive)
            .HasColumnType("BOOLEAN")
            .HasColumnName("is_active")
            .IsRequired();

        builder.Property(c => c.LastUpdatedDate)
            .HasColumnType("TIMESTAMP")
            .HasColumnName("last_updated_date")
            .IsRequired();
    }
}
