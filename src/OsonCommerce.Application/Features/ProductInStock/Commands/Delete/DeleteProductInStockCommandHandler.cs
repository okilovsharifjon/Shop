using MediatR;
using OsonCommerce.Application.Interfaces;
using OsonCommerce.Domain.Entities;
using OsonCommerce.Application.Exceptions;

namespace OsonCommerce.Application.Features;

public class DeleteProductInStockCommandHandler : IRequestHandler<DeleteProductInStockCommand>
{
    private readonly IRepository<ProductInStock> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteProductInStockCommandHandler(IRepository<ProductInStock> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteProductInStockCommand request, CancellationToken cancellationToken)
    {
        if (request.Id == Guid.Empty)
            throw new EmptyRequestException("Id is required");

        await _repository.DeleteAsync(request.Id, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}