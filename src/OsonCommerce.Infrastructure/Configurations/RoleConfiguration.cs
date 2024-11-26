using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using OsonCommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsonCommerce.Infrastructure.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("role");

            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .HasColumnType("integer")
                .HasColumnName("id");

            builder
                .Property(x => x.Name)
                .HasColumnType("VARCHAR(50)")
                .HasColumnName("name")
                .IsRequired();

            var roles = Enum
                .GetValues<Domain.Enums.Role>()
                .Select(r => new Role
                {
                    Id = (int)r,
                    Name = r.ToString()
                });
            builder.HasData(roles);
        }
    }
}
