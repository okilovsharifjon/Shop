using Microsoft.EntityFrameworkCore;
using OsonCommerce.Application.Interfaces.Repositories;

namespace OsonCommerce.Infrastructure.Repositories;

public class Repository<T>(
    OsonCommerceDbContext context
    ) : IRepository<T> where T : class
{
    private readonly OsonCommerceDbContext _context = context;

    public async Task<List<T>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Set<T>().AsNoTracking().ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<T>> GetPagedAsync(int page, int pageSize)
    {
        return await _context.Set<T>()
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async virtual Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Set<T>().FindAsync(id, cancellationToken);
    }

    public async virtual Task<T> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _context.Set<T>().FindAsync(id, cancellationToken);
    }

    public async Task<T> GetByIdAsync(Guid id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task<T> GetByIdAsNoTrackingAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(e 
        => e.GetType().GetProperty("Id").GetValue(e).Equals(id), cancellationToken);
    }

    public virtual async Task<Guid> CreateAsync(T entity, CancellationToken cancellationToken = default)
    {
        await _context.Set<T>().AddAsync(entity, cancellationToken);
        return entity.GetType().GetProperty("Id")
        .GetValue(entity) as Guid? ?? Guid.Empty;
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var entity = await GetByIdAsync(id, cancellationToken);
        if (entity != null)
        {
            _context.Set<T>().Remove(entity);
        }
    }

    public async Task<int> GetTotalCountAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Set<T>().CountAsync(cancellationToken);
    }
}
