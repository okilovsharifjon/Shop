using MediatR;
using OsonCommerce.Application.Interfaces;
using OsonCommerce.Domain.Entities;
using OsonCommerce.Application.Common.Exceptions;
using OsonCommerce.Application.Interfaces.Repositories;

namespace OsonCommerce.Application.Features;

public class DeleteProductInStockCommandHandler(
    IRepository<ProductInStock> repository, 
    IUnitOfWork unitOfWork
    ) : IRequestHandler<DeleteProductInStockCommand>
{
    private readonly IRepository<ProductInStock> _repository = repository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task Handle(DeleteProductInStockCommand request, CancellationToken cancellationToken)
    {
        if (request.Id == Guid.Empty)
            throw new EmptyRequestException("Id is required");

        await _repository.DeleteAsync(request.Id, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}