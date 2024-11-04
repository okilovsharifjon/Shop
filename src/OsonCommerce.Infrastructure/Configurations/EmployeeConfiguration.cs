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

            builder.Property(e => e.Id)
                .HasColumnType("UUID")
                .HasColumnName("id")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(e => e.FirstName)
                .HasColumnType("VARCHAR")
                .HasColumnName("first_name")
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.LastName)
                .HasColumnType("VARCHAR")
                .HasColumnName("last_name")
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.Email)
                .HasColumnType("VARCHAR")
                .HasColumnName("email")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.PhoneNumber)
                .HasColumnType("VARCHAR")
                .HasColumnName("phone_number")
                .HasMaxLength(15);

            builder.Property(e => e.Position)
                .HasColumnType("VARCHAR")
                .HasColumnName("position")
                .HasMaxLength(50);

            builder.Property(e => e.Department)
                .HasColumnType("VARCHAR")
                .HasColumnName("department")
                .HasMaxLength(50);

            builder.Property(e => e.HireDate)
                .HasColumnType("TIMESTAMP")
                .HasColumnName("hire_date")
                .IsRequired();

            builder.Property(e => e.IsActive)
                .HasColumnType("BOOLEAN")
                .HasColumnName("is_active")
                .IsRequired();
        }
    }
}
