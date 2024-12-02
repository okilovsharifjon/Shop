using MediatR;
using FluentValidation;
using OsonCommerce.Application.Interfaces;
using OsonCommerce.Domain.Entities;
using OsonCommerce.Application.Common.Exceptions;
using OsonCommerce.Application.Interfaces.Repositories;

namespace OsonCommerce.Application.Features;

public class UpdateProductCommandHandler(
    IProductRepository repository, 
    IValidator<UpdateProductCommand> validator, 
    IUnitOfWork unitOfWork
    ) : IRequestHandler<UpdateProductCommand>
{
    private readonly IProductRepository _repository = repository;
    private readonly IValidator<UpdateProductCommand> _validator = validator;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAsync(request, cancellationToken);

        var product = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (product == null)
        {
            throw new NotFoundException("Product not found");
        }
        product.Name = request.Name;
        product.CategoryId = request.CategoryId;
        product.ImageName = request.ImageName;
        product.Description = request.Description;
        product.Weight = request.Weight;
        product.ExpiryDate = request.ExpiryDate;
        product.ManufactureDate = request.ManufactureDate;
        product.UpdatedAt = DateTime.UtcNow;
        product.ProductAttributeId = request.ProductAttributeId;

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}