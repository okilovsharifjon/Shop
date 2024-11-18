using OsonCommerce.Domain.Entities;

namespace OsonCommerce.Application.Interfaces.Repositories
{
    public interface ICashboxRepository : IRepository<Cashbox>
    {
        Task<Cashbox> GetCashboxWithDetailsAsync(Guid id, CancellationToken cancellationToken);
    }
}