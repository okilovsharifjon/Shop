using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OsonCommerce.Domain.Entities;

namespace OsonCommerce.Infrastructure.Configurations
{
    public class CashboxOperationConfiguration : IEntityTypeConfiguration<CashboxOperation>
    {
    public void Configure(EntityTypeBuilder<CashboxOperation> builder)
    {
        builder.ToTable("cashbox_operation");
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Amount)
            .HasColumnType("decimal(18,2)")
            .HasColumnName("amount")
            .IsRequired();

        builder.Property(t => t.Date)
            .HasColumnName("date")
            .IsRequired();

        builder.Property(t => t.Description)
            .HasColumnType("VARCHAR")
            .HasColumnName("description")
            .HasMaxLength(500);


        


    }
}
