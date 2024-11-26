using OsonCommerce.Application.Interfaces.Repositories;
using OsonCommerce.Domain.Entities;

namespace OsonCommerce.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
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


        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
}