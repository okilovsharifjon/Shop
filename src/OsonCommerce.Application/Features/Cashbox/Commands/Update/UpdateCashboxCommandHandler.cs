using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OsonCommerce.Domain.Entities;
using OsonCommerce.Application.Common.Exceptions;
using FluentValidation;
using OsonCommerce.Application.Interfaces;
using OsonCommerce.Application.Interfaces.Repositories;

namespace OsonCommerce.Application.Features;

public class UpdateCashboxCommandHandler(
    ICashboxRepository repository, 
    IValidator<UpdateCashboxCommand> validator, 
    IUnitOfWork unitOfWork
    ) : IRequestHandler<UpdateCashboxCommand>
{
    private readonly ICashboxRepository _repository = repository;
    private readonly IValidator<UpdateCashboxCommand> _validator = validator;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task Handle(UpdateCashboxCommand request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAsync(request, cancellationToken);
        var cashbox = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (cashbox == null)
        {
            throw new NotFoundException("Cashbox not found");
        }

        cashbox.Name = request.Name;
        cashbox.Key = request.Key;
        cashbox.IsActive = request.IsActive;

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}

