namespace OsonCommerce.Application.Interfaces.Repositories;

public interface IRepository<T> where T : class
{
    Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<T> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<T> GetByIdAsync(Guid id);
    Task<T> GetByIdAsNoTrackingAsync(Guid id, CancellationToken cancellationToken);
    Task<List<T>> GetAllAsync(CancellationToken cancellationToken);
    Task<IEnumerable<T>> GetPagedAsync(int page, int pageSize);
    Task<Guid> CreateAsync(T entity, CancellationToken cancellationToken);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    Task<int> GetTotalCountAsync(CancellationToken cancellationToken);
}
