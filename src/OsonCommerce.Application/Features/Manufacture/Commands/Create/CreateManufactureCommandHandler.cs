using MediatR;
using FluentValidation;
using OsonCommerce.Domain.Entities;
using OsonCommerce.Application.Interfaces;
using OsonCommerce.Application.Interfaces.Repositories;

namespace OsonCommerce.Application.Features;

public class CreateManufactureCommandHandler(
    IRepository<Manufacture> repository, 
    IUnitOfWork unitOfWork, IValidator<CreateManufactureCommand> validator
    ) : IRequestHandler<CreateManufactureCommand, Guid>
{
    private readonly IRepository<Manufacture> _repository = repository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IValidator<CreateManufactureCommand> _validator = validator;

    public async Task<Guid> Handle(CreateManufactureCommand request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAsync(request, cancellationToken);
        var manufacture = new Manufacture
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Description = request.Description,
            LogoName = request.LogoName,
            WebsiteUrl = request.WebsiteUrl,
            CountryOfOrigin = request.CountryOfOrigin,
            IsActive = request.IsActive
        };

        await _repository.CreateAsync(manufacture, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return manufacture.Id;
    }
}