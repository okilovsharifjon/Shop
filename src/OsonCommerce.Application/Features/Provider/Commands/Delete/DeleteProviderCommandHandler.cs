using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OsonCommerce.Application.Interfaces;
using OsonCommerce.Domain.Entities;
using OsonCommerce.Application.Common.Exceptions;
using OsonCommerce.Application.Interfaces.Repositories;

namespace OsonCommerce.Application.Features;

public class DeleteProviderCommandHandler(
    IRepository<Provider> repository, 
    IUnitOfWork unitOfWork
    ) : IRequestHandler<DeleteProviderCommand>
{
    private readonly IRepository<Provider> _repository = repository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task Handle(DeleteProviderCommand request, CancellationToken cancellationToken)
    {
        if (request.Id == Guid.Empty)
            throw new EmptyRequestException("Id is required");

        await _repository.DeleteAsync(request.Id, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}

