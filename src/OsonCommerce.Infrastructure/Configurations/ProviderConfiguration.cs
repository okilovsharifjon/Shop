using OsonCommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OsonCommerce.Infrastructure.Configurations
{
    public class ProviderConfiguration : IEntityTypeConfiguration<Provider>
    {
        public void Configure(EntityTypeBuilder<Provider> builder)
        {
            builder.ToTable("provider");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnType("UUID")
                .HasColumnName("id")
                .IsRequired();

            builder.Property(p => p.Name)
                .HasColumnType("VARCHAR")
                .HasColumnName("name")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.ContactInfo)
                .HasColumnType("VARCHAR")
                .HasColumnName("contact_info")
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(p => p.Address)
                .HasColumnType("VARCHAR")
                .HasColumnName("address")
                .IsRequired()
                .HasMaxLength(300);

            builder.Property(p => p.Email)
                .HasColumnType("VARCHAR")
                .HasColumnName("email")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Description)
                .HasColumnType("VARCHAR")
                .HasColumnName("description")
                .HasMaxLength(500);

            builder.Property(p => p.IsActive)
                .HasColumnType("BOOLEAN")
                .HasColumnName("is_active")
                .IsRequired()
                .HasDefaultValue(true);
        }
    }
}
