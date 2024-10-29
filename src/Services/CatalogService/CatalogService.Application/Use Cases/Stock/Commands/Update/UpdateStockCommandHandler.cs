using System.Threading;
using System.Threading.Tasks;
using MediatR;
using FluentValidation;
using CatalogService.Application.Interfaces;
using CatalogService.Domain.Entities;
using CatalogService.Application.Exceptions;

namespace CatalogService.Application.UseCases
{
    public class UpdateStockCommandHandler : IRequestHandler<UpdateStockCommand>
    {
        private readonly IRepository<Stock> _repository;
        private readonly IValidator<UpdateStockCommand> _validator;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateStockCommandHandler(IRepository<Stock> repository, IValidator<UpdateStockCommand> validator, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _validator = validator;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateStockCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAsync(request, cancellationToken);
            var stock = await _repository.GetByIdAsync(request.Id, cancellationToken);
            if (stock == null)
            {
                throw new NotFoundException("Stock not found");
            }

            stock.Name = request.Name;
            stock.StockCode = request.StockCode;
            stock.Location = request.Location;
            stock.Capacity = request.Capacity;
            stock.CurrentLoad = request.CurrentLoad;
            stock.PhoneNumber = request.PhoneNumber;
            stock.IsAvailable = request.IsAvailable;
            
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}

