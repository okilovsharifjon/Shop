using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OsonCommerce.Domain.Entities;

namespace OsonCommerce.Infrastructure.Configurations;

public class CashboxOperationConfiguration : IEntityTypeConfiguration<CashboxOperation>
{
    public void Configure(EntityTypeBuilder<CashboxOperation> builder)
    {
        builder.ToTable("cashbox_operation");
        builder.HasKey(t => t.Id);

        builder.Property(c => c.Id)
            .HasColumnType("UUID")
            .HasColumnName("id")
            .IsRequired();

        builder.Property(c => c.CashboxId)
            .HasColumnType("UUID")
            .HasColumnName("cashbox_id")
            .IsRequired();

        builder.Property(c => c.EmployeeId)
            .HasColumnType("UUID")
            .HasColumnName("employee_id")
            .IsRequired();

        builder.Property(t => t.Amount)
            .HasColumnType("decimal(18,2)")
            .HasColumnName("amount")
            .IsRequired();

        builder.Property(t => t.Date)
            .HasColumnType("TIMESTAMP WITH TIME ZONE")
            .HasColumnName("date")
            .IsRequired();

        builder.Property(t => t.Description)
            .HasColumnType("VARCHAR")
            .HasColumnName("description")
            .HasMaxLength(500);

        builder.Property(t => t.TransactionType)
            .HasColumnName("transaction_type")
            .IsRequired();

        builder.Property(t => t.Status)
            .HasColumnName("status")
            .IsRequired();

        builder.HasOne(t => t.Employee)
            .WithMany()
            .HasForeignKey(t => t.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(t => t.Cashbox)
            .WithMany()
            .HasForeignKey(t => t.CashboxId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
