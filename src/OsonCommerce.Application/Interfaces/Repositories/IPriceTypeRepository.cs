using OsonCommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsonCommerce.Application.Interfaces.Repositories
{
    public interface IPriceTypeRepository : IRepository<PriceType>
    {
        Task<Guid> CreateAsync(PriceType entity, CancellationToken cancellationToken = default);
    }
}
