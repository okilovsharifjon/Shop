using OsonCommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OsonCommerce.Infrastructure.Configurations;

public class StoreBranchConfiguration : IEntityTypeConfiguration<StoreBranch>
{
    public void Configure(EntityTypeBuilder<StoreBranch> builder)
    {
        builder.ToTable("store_branch");
        builder.HasKey(sb => sb.Id);

        builder.Property(sb => sb.Name)
            .HasColumnName("name")
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(sb => sb.ManagerIds)
            .HasColumnType("uuid[]")
            .HasColumnName("manager_ids")
            .IsRequired();

        builder.Property(sb => sb.Address)
            .HasColumnName("address")
            .IsRequired(false)
            .HasMaxLength(200);

        builder.Property(sb => sb.PhoneNumber)
            .HasColumnName("phone_number")
            .IsRequired(false)
            .HasMaxLength(15);

        builder.Property(sb => sb.Email)
            .HasColumnName("email")
            .HasMaxLength(100);

        builder.Property(sb => sb.OperatingHours)
            .HasMaxLength(50);

        builder.Property(sb => sb.IsActive)
            .IsRequired();

        builder.HasMany(sb => sb.Managers)
            .WithOne();

    }
}
