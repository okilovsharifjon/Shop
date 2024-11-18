using OsonCommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OsonCommerce.Infrastructure.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("category");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnType("UUID")
                .HasColumnName("id")
                .IsRequired();

            builder.Property(c => c.Name)
                .HasColumnType("VARCHAR")
                .HasColumnName("name")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.Description)
                .HasColumnType("VARCHAR")
                .HasColumnName("description")
                .HasMaxLength(500);

            builder.HasMany(c => c.Products)
                .WithOne()
                .HasForeignKey(p => p.CategoryId)
                .IsRequired();
        }
    }
}
