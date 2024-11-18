using MediatR;
using OsonCommerce.Application.Exceptions;
using OsonCommerce.Application.Interfaces;
using OsonCommerce.Application.Interfaces.Repositories;
using OsonCommerce.Domain.Entities;

namespace OsonCommerce.Application.Features;

public class UpdateProductInStockCommandHandler : IRequestHandler<UpdateProductInStockCommand>
{
    private readonly IRepository<ProductInStock> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateProductInStockCommandHandler(IRepository<ProductInStock> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

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
