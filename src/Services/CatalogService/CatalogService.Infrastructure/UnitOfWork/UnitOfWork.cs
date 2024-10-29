using CatalogService.Application.Interfaces;
using CatalogService.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace CatalogService.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CatalogDbContext _dbContext;
        public IRepository<Cashbox> Cashboxes { get; }
        public IRepository<Stock> Stocks { get; }
        public IRepository<Product> Products { get; }
        public IRepository<Provider> Providers { get; }
        public UnitOfWork(CatalogDbContext dbContext,
        IRepository<Cashbox> cashboxes,
        IRepository<Stock> stocks,
        IRepository<Product> products,
        IRepository<Provider> providers)
        {
            _dbContext = dbContext;
            Cashboxes = cashboxes;
            Stocks = stocks;
            Products = products;
            Providers = providers;
        }



        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {

            _dbContext.Dispose();
        }
    }
}
