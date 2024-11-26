using OsonCommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OsonCommerce.Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace OsonCommerce.Infrastructure.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly OsonCommerceDbContext _context;

        public ProductRepository(OsonCommerceDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Product> GetBySku(string sku, CancellationToken cancellationToken)
        {
            return await _context.Products.AsNoTracking().FirstOrDefaultAsync(p => p.SKU.Equals(sku), cancellationToken);
        }
    }
}
