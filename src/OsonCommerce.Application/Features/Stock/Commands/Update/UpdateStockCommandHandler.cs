using System.Threading;
using System.Threading.Tasks;
using MediatR;
using FluentValidation;
using OsonCommerce.Application.Interfaces;
using OsonCommerce.Domain.Entities;
using OsonCommerce.Application.Common.Exceptions;
using OsonCommerce.Application.Interfaces.Repositories;

namespace OsonCommerce.Application.Features;

public class UpdateStockCommandHandler(
    IRepository<Stock> repository,
    IValidator<UpdateStockCommand> validator,
    IUnitOfWork unitOfWork
    ) : IRequestHandler<UpdateStockCommand>
{
    private readonly IRepository<Stock> _repository = repository;
    private readonly IValidator<UpdateStockCommand> _validator = validator;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

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

