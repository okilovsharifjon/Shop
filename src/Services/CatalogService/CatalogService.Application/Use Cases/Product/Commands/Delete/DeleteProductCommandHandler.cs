using System.Threading;
using System.Threading.Tasks;
using CatalogService.Domain.Entities;
using MediatR;
using FluentValidation;
using CatalogService.Application.Interfaces;

namespace CatalogService.Application.UseCases
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IValidator<DeleteProductCommand> _validator;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteProductCommandHandler(IRepository<Product> productRepository, IValidator<DeleteProductCommand> validator, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _validator = validator;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAsync(request, cancellationToken);
            await _productRepository.DeleteAsync(request.Id, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}