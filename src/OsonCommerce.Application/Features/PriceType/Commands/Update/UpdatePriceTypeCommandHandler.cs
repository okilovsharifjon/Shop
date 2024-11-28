using OsonCommerce.Domain.Entities;
using MediatR;
using OsonCommerce.Application.Interfaces;
using FluentValidation;
using OsonCommerce.Application.Interfaces.Repositories;

namespace OsonCommerce.Application.Features;

public class UpdatePriceTypeCommandHandler(
    IRepository<PriceType> repository,
    IUnitOfWork unitOfWork,
    IValidator<UpdatePriceTypeCommand> validator
    ) : IRequestHandler<UpdatePriceTypeCommand>
{
    private readonly IRepository<PriceType> _repository = repository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IValidator<UpdatePriceTypeCommand> _validator = validator;

    public async Task Handle(UpdatePriceTypeCommand request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(request, cancellationToken);
        var priceType = await _repository.GetByIdAsync(request.Id, cancellationToken);
        priceType.Name = request.Name;
        priceType.Description = request.Description;
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}