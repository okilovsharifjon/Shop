using MediatR;
using OsonCommerce.Domain.Entities;
using OsonCommerce.Application.Interfaces;
using OsonCommerce.Application.Interfaces.Repositories;

namespace OsonCommerce.Application.Features;

public class CreateProductInStockCommandHandler : IRequestHandler<CreateProductInStockCommand, Guid>
{
    private readonly IRepository<ProductInStock> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateProductInStockCommandHandler(IRepository<ProductInStock> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateProductInStockCommand request, CancellationToken cancellationToken)
    {
        var productInStock = new ProductInStock
        {
            Id = Guid.NewGuid(),
            ProductId = request.ProductId,
            StockId = request.StockId,
            ProviderId = request.ProviderId,
            Quantity = request.Quantity,
            ProductPriceId = request.ProductPriceId,
            IsAvailable = request.IsAvailable,
        };

        await _repository.CreateAsync(productInStock, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return productInStock.Id;
    }
}