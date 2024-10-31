using OsonCommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OsonCommerce.Infrastructure.Configurations
{
    public class StockConfiguration : IEntityTypeConfiguration<Stock>
    {
        public void Configure(EntityTypeBuilder<Stock> builder)
    {
        builder.ToTable("stock");
        builder.HasKey(s => s.Id);

        
        builder.Property(s => s.Id)
            .HasColumnType("UUID")
            .HasColumnName("id")
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder.Property(s => s.Name)
            .HasColumnType("VARCHAR")
            .HasColumnName("name")
            .IsRequired();

        builder.Property(s => s.StockCode)
            .HasColumnType("VARCHAR")
            .HasColumnName("stock_code")
            .IsRequired();

        builder.Property(s => s.Location)
            .HasColumnType("VARCHAR")
            .HasColumnName("location")
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(s => s.Capacity)
            .HasColumnType("INTEGER")
            .HasColumnName("capacity")
            .IsRequired();

        builder.Property(s => s.CurrentLoad)
            .HasColumnType("INTEGER")
            .HasColumnName("current_load")
            .IsRequired();

        builder.Property(s => s.PhoneNumber)
            .HasColumnType("VARCHAR")
            .HasColumnName("phone_number");

        builder.Property(s => s.IsAvailable)
            .HasColumnType("BOOLEAN")
            .HasColumnName("is_available")
            .IsRequired();
    }
}
