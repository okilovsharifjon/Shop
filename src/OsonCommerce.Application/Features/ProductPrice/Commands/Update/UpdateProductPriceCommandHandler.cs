using OsonCommerce.Domain.Entities;
using MediatR;
using OsonCommerce.Application.Interfaces;
using FluentValidation;
using OsonCommerce.Application.Interfaces.Repositories;

namespace OsonCommerce.Application.Features;

public class UpdateProductPriceCommandHandler(
    IRepository<ProductPrice> repository,
    IUnitOfWork unitOfWork,
    IValidator<UpdateProductPriceCommand> validator
    ) : IRequestHandler<UpdateProductPriceCommand>
{
    private readonly IRepository<ProductPrice> _repository = repository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IValidator<UpdateProductPriceCommand> _validator = validator;

    public async Task Handle(UpdateProductPriceCommand request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(request, cancellationToken);
        var productPrice = await _repository.GetByIdAsync(request.ProductPriceID, cancellationToken);
        productPrice.Price = request.Price;
        productPrice.ProductID = request.ProductID;
        productPrice.PriceTypeID = request.PriceTypeID;
        productPrice.StockID = request.StockID;
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}