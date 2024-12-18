using System.Threading;
using System.Threading.Tasks;
using MediatR;
using FluentValidation;
using OsonCommerce.Application.Interfaces;
using OsonCommerce.Domain.Entities;
using OsonCommerce.Application.Interfaces.Repositories;

namespace OsonCommerce.Application.Features;

public class CreateProviderCommandHandler(
    IRepository<Provider> repository, 
    IValidator<CreateProviderCommand> validator, 
    IUnitOfWork unitOfWork
    ) : IRequestHandler<CreateProviderCommand, Guid>
{
    private readonly IRepository<Provider> _repository = repository;
    private readonly IValidator<CreateProviderCommand> _validator = validator;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Guid> Handle(CreateProviderCommand request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAsync(request, cancellationToken);

        var provider = new Provider
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            ContactInfo = request.ContactInfo,
            Address = request.Address,
            Email = request.Email,
            Description = request.Description,
            IsActive = request.IsActive
        };

        await _repository.CreateAsync(provider, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return provider.Id;
    }
}

