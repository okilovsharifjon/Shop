using System.Threading;
using System.Threading.Tasks;
using MediatR;
using FluentValidation;
using OsonCommerce.Application.Interfaces;
using OsonCommerce.Domain.Entities;
using OsonCommerce.Application.Interfaces.Repositories;

namespace OsonCommerce.Application.Features;

public class DeleteStockCommandHandler(
    IRepository<Stock> repository, 
    IValidator<DeleteStockCommand> validator, 
    IUnitOfWork unitOfWork
    ) : IRequestHandler<DeleteStockCommand>
{
    private readonly IRepository<Stock> _repository = repository;
    private readonly IValidator<DeleteStockCommand> _validator = validator;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task Handle(DeleteStockCommand request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAsync(request, cancellationToken);
        await _repository.DeleteAsync(request.Id, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}

