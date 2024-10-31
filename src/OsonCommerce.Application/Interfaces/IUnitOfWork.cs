using OsonCommerce.Domain.Entities;

namespace OsonCommerce.Application.Interfaces
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