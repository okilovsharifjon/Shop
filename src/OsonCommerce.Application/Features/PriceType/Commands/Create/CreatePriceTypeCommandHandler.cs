using FluentValidation;
using MediatR;
using OsonCommerce.Application.Interfaces;
using OsonCommerce.Application.Interfaces.Repositories;
using OsonCommerce.Domain.Entities;

namespace OsonCommerce.Application.Features;

public class CreatePriceTypeCommandHandler(
    IPriceTypeRepository repository,
    IUnitOfWork unitOfWork,
    IValidator<CreatePriceTypeCommand> validator
    ) : IRequestHandler<CreatePriceTypeCommand, Guid>
{
    private readonly IPriceTypeRepository _repository = repository;
    private readonly IValidator<CreatePriceTypeCommand> _validator = validator;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Guid> Handle(CreatePriceTypeCommand request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAsync(request, cancellationToken);

        var priceType = new PriceType
        {
            PriceTypeID = Guid.NewGuid(),
            Name = request.Name,
            Description = request.Description
        };

        await _repository.CreateAsync(priceType, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return priceType.PriceTypeID;
    }
}

