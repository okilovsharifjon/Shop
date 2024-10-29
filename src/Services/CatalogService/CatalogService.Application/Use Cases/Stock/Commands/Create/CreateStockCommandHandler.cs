using System.Threading;
using System.Threading.Tasks;
using MediatR;
using FluentValidation;
using CatalogService.Application.Interfaces;
using CatalogService.Domain.Entities;

namespace CatalogService.Application.UseCases
{
    public class CreateStockCommandHandler : IRequestHandler<CreateStockCommand, Guid>
    {
        private readonly IRepository<Stock> _repository;
        private readonly IValidator<CreateStockCommand> _validator;
        private readonly IUnitOfWork _unitOfWork;

        public CreateStockCommandHandler(IRepository<Stock> repository, IValidator<CreateStockCommand> validator, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _validator = validator;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateStockCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAsync(request, cancellationToken);

            var stock = new Stock
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                StockCode = request.StockCode,
                Location = request.Location,
                Capacity = request.Capacity,
                CurrentLoad = request.CurrentLoad,
                PhoneNumber = request.PhoneNumber,
                IsAvailable = request.IsAvailable
            };

            await _repository.CreateAsync(stock, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return stock.Id;
        }
    }
}

