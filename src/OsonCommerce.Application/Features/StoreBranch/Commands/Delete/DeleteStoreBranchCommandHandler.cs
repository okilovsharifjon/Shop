using MediatR;
using OsonCommerce.Application.Interfaces;
using OsonCommerce.Application.Exceptions;

namespace OsonCommerce.Application.Features;

public class DeleteStoreBranchCommandHandler : IRequestHandler<DeleteStoreBranchCommand>
{
    private readonly IRepository<StoreBranch> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteStoreBranchCommandHandler(IRepository<StoreBranch> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteStoreBranchCommand request, CancellationToken cancellationToken)
    {
        if (request.Id == Guid.Empty)
            throw new EmptyRequestException("Id is required");

        await _repository.DeleteAsync(request.Id, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
} 