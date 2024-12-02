using MediatR;
using OsonCommerce.Application.Common.Exceptions;
using OsonCommerce.Application.Interfaces;
using OsonCommerce.Application.Interfaces.Repositories;
using OsonCommerce.Domain.Entities;

namespace OsonCommerce.Application.Features;

public class UpdateProductInStockCommandHandler(
    IRepository<ProductInStock> repository, 
    IUnitOfWork unitOfWork
    ) : IRequestHandler<UpdateProductInStockCommand>
{
    private readonly IRepository<ProductInStock> _repository = repository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task Handle(UpdateProductInStockCommand request, CancellationToken cancellationToken)
    {
        var productInStock = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (productInStock == null)
        {
            throw new NotFoundException("Product in stock not found");
        }

        productInStock.ProductId = request.ProductId;
        productInStock.StockId = request.StockId;
        productInStock.ProviderId = request.ProviderId;
        productInStock.ProductPriceId = request.ProductPriceId;
        productInStock.Quantity = request.Quantity;
        productInStock.IsAvailable = request.IsAvailable;

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
