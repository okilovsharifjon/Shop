using System.Threading;
using System.Threading.Tasks;
using MediatR;
using FluentValidation;
using CatalogService.Application.Interfaces;
using CatalogService.Domain.Entities;

namespace CatalogService.Application.UseCases
{
    public class DeleteStockCommandHandler : IRequestHandler<DeleteStockCommand>
    {
        private readonly IRepository<Stock> _repository;
        private readonly IValidator<DeleteStockCommand> _validator;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteStockCommandHandler(IRepository<Stock> repository, IValidator<DeleteStockCommand> validator, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _validator = validator;
            _unitOfWork = unitOfWork;
            }

        public async Task Handle(DeleteStockCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAsync(request, cancellationToken);
            await _repository.DeleteAsync(request.Id, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}

