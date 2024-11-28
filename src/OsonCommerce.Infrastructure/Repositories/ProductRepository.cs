using OsonCommerce.Domain.Entities;
using OsonCommerce.Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace OsonCommerce.Infrastructure.Repositories
{
    public class ProductRepository(
        OsonCommerceDbContext context
        ) : Repository<Product>(context), IProductRepository
    {
        private readonly OsonCommerceDbContext _context = context;

        public async Task<Product> GetBySku(string sku, CancellationToken cancellationToken)
        {
            return await _context.Products.AsNoTracking().FirstOrDefaultAsync(p => p.SKU.Equals(sku), cancellationToken);
        }
    }
}
