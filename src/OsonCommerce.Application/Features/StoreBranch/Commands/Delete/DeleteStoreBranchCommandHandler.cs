using MediatR;
using OsonCommerce.Application.Interfaces;
using OsonCommerce.Application.Exceptions;
using OsonCommerce.Domain.Entities;
using OsonCommerce.Application.Interfaces.Repositories;


namespace OsonCommerce.Application.Features;

public class DeleteStoreBranchCommandHandler(
    IRepository<StoreBranch> repository, 
    IUnitOfWork unitOfWork
    ) : IRequestHandler<DeleteStoreBranchCommand>
{
    private readonly IRepository<StoreBranch> _repository = repository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task Handle(DeleteStoreBranchCommand request, CancellationToken cancellationToken)
    {
        if (request.Id == Guid.Empty)
            throw new EmptyRequestException("Id is required");

        await _repository.DeleteAsync(request.Id, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
} 