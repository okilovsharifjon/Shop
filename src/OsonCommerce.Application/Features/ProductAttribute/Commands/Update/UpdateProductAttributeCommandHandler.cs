using OsonCommerce.Domain.Entities;
using MediatR;
using OsonCommerce.Application.Interfaces;
using FluentValidation;
using OsonCommerce.Application.Interfaces.Repositories;

namespace OsonCommerce.Application.Features;

public class UpdateProductAttributeCommandHandler(
    IRepository<ProductAttribute> repository,
    IUnitOfWork unitOfWork,
    IValidator<UpdateProductAttributeCommand> validator
    ) : IRequestHandler<UpdateProductAttributeCommand>
{
    private readonly IRepository<ProductAttribute> _repository = repository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IValidator<UpdateProductAttributeCommand> _validator = validator;

    public async Task Handle(UpdateProductAttributeCommand request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(request, cancellationToken);
        var productAttribute = await _repository.GetByIdAsync(request.Id, cancellationToken);
        productAttribute.Name = request.Name;
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}