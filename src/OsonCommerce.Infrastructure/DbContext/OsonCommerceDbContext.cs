using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OsonCommerce.Domain;
using OsonCommerce.Domain.Entities;
using OsonCommerce.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using OsonCommerce.Infrastructure.Authorization;
using OsonCommerce.Infrastructure.Authentication;

namespace OsonCommerce.Infrastructure
{
    public class OsonCommerceDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<ProductInStock> ProductInStocks { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CashboxOperation> CashboxOperations { get; set; }
        public DbSet<Cashbox> Cashboxes { get; set; }
        public DbSet<ProductPrice> ProductPrices { get; set; }
        public DbSet<PriceType> PriceTypes { get; set; }
        public DbSet<ProductAttribute> ProductAttributes { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            SeedAdminData(modelBuilder);
        }

        private void SeedAdminData(ModelBuilder modelBuilder)
        {
            var roleId = 1;
            var adminId = Guid.NewGuid();

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                Id = adminId,
                FirstName = "Admin",
                LastName = "Admin",
                Password = Convert.ToString(new PasswordHasher().Generate("Admin123$")),
                Email = "adminadmin@gmail.com",
                HireDate = DateTime.UtcNow,
                PhoneNumber = "+992-00-000-00-00",
                Department = "Admin",
                IsActive = true,
                Position = "Admin",
            });

            modelBuilder.Entity<UserRole>().HasData(new UserRole
            {
                RoleId = roleId,
                UserId = adminId
            });
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=oson_commerce_dev;Username=postgres;Password=admin;");
        //}
    }
}
