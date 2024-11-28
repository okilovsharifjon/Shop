using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OsonCommerce.Domain.Entities;
using FluentValidation;
using OsonCommerce.Application.Interfaces;
using OsonCommerce.Application.Interfaces.Repositories;

namespace OsonCommerce.Application.Features;

public class CreateCashboxCommandHandler(
    ICashboxRepository repository, 
    IValidator<CreateCashboxCommand> validator, 
    IUnitOfWork unitOfWork
    ) : IRequestHandler<CreateCashboxCommand, Guid>
{
    private readonly ICashboxRepository _repository = repository;
    private readonly IValidator<CreateCashboxCommand> _validator = validator;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Guid> Handle(CreateCashboxCommand request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAsync(request, cancellationToken);

        var cashbox = new Cashbox
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Balance = request.Balance,
            Key = request.Key,
            IsActive = true,
            LastUpdatedDate = DateTime.Now,
            StoreBranchId = request.StoreBranchId,
            CashierIds = request.ChashierIds
        };

        await _repository.CreateAsync(cashbox, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return cashbox.Id;
    }


}

