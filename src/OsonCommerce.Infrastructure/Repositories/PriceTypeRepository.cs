using OsonCommerce.Domain.Entities;
using OsonCommerce.Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace OsonCommerce.Infrastructure.Repositories
{
    public class PriceTypeRepository(
        OsonCommerceDbContext context
        ) : Repository<PriceType>(context), IPriceTypeRepository
    {
        private readonly OsonCommerceDbContext _context = context;

        public override async Task<Guid> CreateAsync(PriceType entity, CancellationToken cancellationToken = default)
        {
            await _context.PriceTypes.AddAsync(entity, cancellationToken);
            return entity.PriceTypeID as Guid? ?? Guid.Empty;
        }
    }
}
