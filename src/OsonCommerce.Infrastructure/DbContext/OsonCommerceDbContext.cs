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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
            => modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=oson_commerce_dev;Username=postgres;Password=admin;");
        //}
    }
}
