using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OsonCommerce.Domain;
using OsonCommerce.Domain.Entities;
using OsonCommerce.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace OsonCommerce.Infrastructure
{
    public class OsonCommerceDbContext(DbContextOptions options)  : DbContext(options)
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<ProductInStock> ProductInStocks { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CashboxOperation> CashboxOperations { get; set; }
        public DbSet<Cashbox> Cashboxes { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new StockConfiguration());
            modelBuilder.ApplyConfiguration(new ProductInStockConfiguration());
            modelBuilder.ApplyConfiguration(new ProviderConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new CashboxConfiguration());
            modelBuilder.ApplyConfiguration(new ManufactureConfiguration());
            modelBuilder.ApplyConfiguration(new CashboxOperationConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new StoreBranchConfiguration());

            base.OnModelCreating(modelBuilder);
            
        }
    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=catalog_service;Username=postgres;Password=admin;");
    //}
    }
}
