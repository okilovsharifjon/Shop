using OsonCommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OsonCommerce.Infrastructure.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("employee");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.PhoneNumber)
                .HasMaxLength(15);

            builder.Property(e => e.Position)
                .HasMaxLength(50);

            builder.Property(e => e.Department)
                .HasMaxLength(50);

            builder.HasOne(e => e.StoreBranch)
                .WithMany()
                .HasForeignKey(e => e.StoreBranchId);

            builder.Property(e => e.HireDate)
                .IsRequired();

            builder.Property(e => e.IsActive)
                .IsRequired();
        }
    }
}
