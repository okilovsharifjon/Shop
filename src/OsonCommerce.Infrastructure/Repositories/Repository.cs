using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OsonCommerce.Application.Interfaces;
using OsonCommerce.Domain.Entities;

namespace OsonCommerce.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
    private readonly DbSet<T> _dbSet;

    public Repository(DbContext context)
    {
        _dbSet = context.Set<T>();
    }

    public async Task<List<T>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _dbSet.AsNoTracking().ToListAsync(cancellationToken);
    }

    public async Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _dbSet.FirstOrDefaultAsync(e => e.GetType().GetProperty("Id").GetValue(e).Equals(id), cancellationToken);
    }

    public async Task<T> GetByIdAsNoTrackingAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _dbSet.AsNoTracking().FirstOrDefaultAsync(e => e.GetType().GetProperty("Id").GetValue(e).Equals(id), cancellationToken);
    }

    public async Task<Guid> CreateAsync(T entity, CancellationToken cancellationToken = default)
    {
        await _dbSet.AddAsync(entity, cancellationToken);
        return entity.GetType().GetProperty("Id").GetValue(entity) as Guid? ?? Guid.Empty;
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var entity = await GetByIdAsync(id, cancellationToken);
        if (entity != null)
        {
            _dbSet.Remove(entity);
        }
    }
}
