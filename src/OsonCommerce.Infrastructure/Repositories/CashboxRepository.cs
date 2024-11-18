using OsonCommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using OsonCommerce.Application.Interfaces.Repositories;


namespace OsonCommerce.Infrastructure.Repositories;

public class CashboxRepository : Repository<Cashbox>, ICashboxRepository
{
    private readonly OsonCommerceDbContext _context;
    public CashboxRepository(OsonCommerceDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Cashbox> GetCashboxWithDetailsAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Cashboxes
            .Include(c => c.Cashiers)
            .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
    }
}