using OsonCommerce.Application.Interfaces;
using OsonCommerce.Application.Interfaces.Repositories;
using OsonCommerce.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace OsonCommerce.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OsonCommerceDbContext _dbContext;
        public ICashboxRepository Cashboxes { get; }
        public IRepository<Stock> Stocks { get; }
        public IProductRepository Products { get; }
        public IRepository<Provider> Providers { get; }
        public IRepository<Category> Categories { get; }
        public IEmployeeRepository Employees { get; }
        public IRepository<Manufacture> Manufactures { get; }
        public IRepository<ProductInStock> ProductsInStock { get; }
        public IRepository<StoreBranch> StoreBranches { get; }
        public IRepository<CashboxOperation> CashboxOperations { get; }
        public UnitOfWork(OsonCommerceDbContext dbContext,
        ICashboxRepository cashboxes,
        IRepository<Stock> stocks,
        IProductRepository products,
        IRepository<Provider> providers,
        IRepository<Category> categories,
        IEmployeeRepository employees,
        IRepository<Manufacture> manufactures,
        IRepository<ProductInStock> productsInStock,
        IRepository<StoreBranch> storeBranches,
        IRepository<CashboxOperation> cashboxOperations)
        {
            _dbContext = dbContext;
            Cashboxes = cashboxes;
            Stocks = stocks;
            Products = products;
            Providers = providers;
            Categories = categories;
            Employees = employees;
            Manufactures = manufactures;
            ProductsInStock = productsInStock;
            StoreBranches = storeBranches;
            CashboxOperations = cashboxOperations;
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
