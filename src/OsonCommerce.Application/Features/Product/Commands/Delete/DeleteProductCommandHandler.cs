using System.Threading;
using System.Threading.Tasks;
using OsonCommerce.Domain.Entities;
using MediatR;
using OsonCommerce.Application.Interfaces;
using OsonCommerce.Application.Common.Exceptions;
using OsonCommerce.Application.Interfaces.Repositories;

namespace OsonCommerce.Application.Features;

public class DeleteProductCommandHandler(
    IProductRepository productRepository, 
    IUnitOfWork unitOfWork
    ) : IRequestHandler<DeleteProductCommand>
{
    private readonly IProductRepository _productRepository = productRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        if (request.Id == Guid.Empty)
        {
            throw new EmptyRequestException("Id is required");
        }

        await _productRepository.DeleteAsync(request.Id, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}