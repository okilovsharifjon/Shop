using OsonCommerce.Domain.Entities;
using MediatR;
using FluentValidation;
using OsonCommerce.Application.Interfaces;
using OsonCommerce.Application.Interfaces.Repositories;

namespace OsonCommerce.Application.Features;

public class CreateProductAttributeCommandHandler(
    IRepository<ProductAttribute> repository,
    IValidator<CreateProductAttributeCommand> validator,
    IUnitOfWork unitOfWork
    ) : IRequestHandler<CreateProductAttributeCommand, Guid>
{
    private readonly IRepository<ProductAttribute> _repository = repository;
    private readonly IValidator<CreateProductAttributeCommand> _validator = validator;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Guid> Handle(CreateProductAttributeCommand request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(request, cancellationToken);
        var productAttribute = new ProductAttribute
        {
            ProductAttributeID = Guid.NewGuid(),
            Name = request.Name
        };
        await _repository.CreateAsync(productAttribute, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return productAttribute.ProductAttributeID;
    }
}