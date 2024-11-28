using OsonCommerce.Application.Interfaces;
using OsonCommerce.Application.Interfaces.Repositories;
using OsonCommerce.Domain.Entities;

namespace OsonCommerce.Infrastructure;

public class UnitOfWork(
    OsonCommerceDbContext dbContext,
    ICashboxRepository cashboxes,
    IRepository<Stock> stocks,
    IProductRepository products,
    IRepository<Provider> providers,
    IRepository<Category> categories,
    IEmployeeRepository employees,
    IRepository<Manufacture> manufactures,
    IRepository<ProductInStock> productsInStock,
    IRepository<StoreBranch> storeBranches,
    IRepository<CashboxOperation> cashboxOperations,
    IRepository<ProductPrice> productPrices,
    IPriceTypeRepository priceTypes,
    IRepository<ProductAttribute> productAttributes 
    ) : IUnitOfWork
{
    private readonly OsonCommerceDbContext _dbContext = dbContext;
    public ICashboxRepository Cashboxes { get; } = cashboxes;
    public IRepository<Stock> Stocks { get; } = stocks;
    public IProductRepository Products { get; } = products;
    public IRepository<Provider> Providers { get; } = providers;
    public IRepository<Category> Categories { get; } = categories;
    public IEmployeeRepository Employees { get; } = employees;
    public IRepository<Manufacture> Manufactures { get; } = manufactures;
    public IRepository<ProductInStock> ProductsInStock { get; } = productsInStock;
    public IRepository<StoreBranch> StoreBranches { get; } = storeBranches;
    public IRepository<CashboxOperation> CashboxOperations { get; } = cashboxOperations;
    public IRepository<ProductPrice> ProductPrices { get; } = productPrices;
    public IPriceTypeRepository PriceTypes { get; } = priceTypes;
    public IRepository<ProductAttribute> ProductAttributes { get; } = productAttributes;

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public void Dispose()
    {

        _dbContext.Dispose();
    }
}
