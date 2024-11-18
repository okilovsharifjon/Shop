using System.Threading;
using System.Threading.Tasks;
using OsonCommerce.Domain.Entities;
using MediatR;
using OsonCommerce.Application.Interfaces;
using OsonCommerce.Application.Exceptions;
using OsonCommerce.Application.Interfaces.Repositories;

namespace OsonCommerce.Application.Features
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteProductCommandHandler(IRepository<Product> productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

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
}