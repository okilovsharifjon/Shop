using FluentValidation;
using MediatR;
using OsonCommerce.Application.Interfaces;
using OsonCommerce.Application.Interfaces.Repositories;
using OsonCommerce.Domain.Entities;

namespace OsonCommerce.Application.Features;

public class CreateProductPriceCommandHandler(
    IRepository<ProductPrice> repository,
    IUnitOfWork unitOfWork,
    IValidator<CreateProductPriceCommand> validator
    ) : IRequestHandler<CreateProductPriceCommand, Guid>
{
    private readonly IRepository<ProductPrice> _repository = repository;
    private readonly IValidator<CreateProductPriceCommand> _validator = validator;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Guid> Handle(CreateProductPriceCommand request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAsync(request, cancellationToken);

        var productPrice = new ProductPrice
        {
            ProductPriceID = Guid.NewGuid(),
            ProductID = request.ProductID,
            StockID = request.StockID,
            PriceTypeID = request.PriceTypeID,
            Price = request.Price
        };

        await _repository.CreateAsync(productPrice, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return productPrice.PriceTypeID;
    }
}

