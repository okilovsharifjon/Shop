using CatalogService.Domain.Entities;

namespace CatalogService.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Cashbox> Cashboxes { get; }
        IRepository<Stock> Stocks { get; }
        IRepository<Product> Products { get; }
        IRepository<Provider> Providers { get; }


        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
}