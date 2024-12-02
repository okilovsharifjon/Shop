using System.Threading;
using System.Threading.Tasks;
using MediatR;
using FluentValidation;
using OsonCommerce.Application.Interfaces;
using OsonCommerce.Domain.Entities;
using OsonCommerce.Application.Common.Exceptions;
using OsonCommerce.Application.Interfaces.Repositories;

namespace OsonCommerce.Application.Features;

public class UpdateProviderCommandHandler(
    IRepository<Provider> repository, 
    IValidator<UpdateProviderCommand> validator, 
    IUnitOfWork unitOfWork
    ) : IRequestHandler<UpdateProviderCommand>
{
    private readonly IRepository<Provider> _repository = repository;
    private readonly IValidator<UpdateProviderCommand> _validator = validator;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task Handle(UpdateProviderCommand request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAsync(request, cancellationToken);

        var provider = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (provider == null)
        {
            throw new NotFoundException("Provider not found");
        }

        provider.Name = request.Name;
        provider.ContactInfo = request.ContactInfo;
        provider.Address = request.Address;
        provider.Description = request.Description;

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}

