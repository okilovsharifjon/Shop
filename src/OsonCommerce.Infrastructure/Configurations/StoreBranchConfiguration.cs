using OsonCommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OsonCommerce.Infrastructure.Configurations
{
    public class StoreBranchConfiguration : IEntityTypeConfiguration<StoreBranch>
    {
        public void Configure(EntityTypeBuilder<StoreBranch> builder)
        {
            builder.ToTable("store_branch");
            builder.HasKey(sb => sb.Id);

            builder.Property(sb => sb.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(sb => sb.Address)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(sb => sb.PhoneNumber)
                .HasMaxLength(15);

            builder.Property(sb => sb.Email)
                .HasMaxLength(100);

            builder.Property(sb => sb.OperatingHours)
                .HasMaxLength(50);

            builder.Property(sb => sb.IsActive)
                .IsRequired();

            builder.Property(sb => sb.NumberOfEmployees)
                .IsRequired();

            builder.HasMany(sb => sb.Managers)
                .WithOne();

            builder.HasMany(sb => sb.Managers)
                .WithOne();

        }
    }
}
