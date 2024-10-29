using CatalogService.Application.Exceptions;
using CatalogService.Domain.Entities;
using System.Net.NetworkInformation;
using MediatR;
using FluentValidation;
using CatalogService.Application.Interfaces;

namespace CatalogService.Application.UseCases
{
    public class AddMoneyToCashboxCommandHandler : IRequestHandler<AddMoneyToCashboxCommand>
    {
        private readonly IRepository<Cashbox> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AddMoneyToCashboxCommand> _validator;

        public AddMoneyToCashboxCommandHandler(IRepository<Cashbox> repository, IUnitOfWork unitOfWork, IValidator<AddMoneyToCashboxCommand> validator)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task Handle(AddMoneyToCashboxCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAsync(request, cancellationToken);
            var cashbox = await _repository.GetByIdAsync(request.CashboxId, cancellationToken);
            if (cashbox == null)
            {
                throw new NotFoundException("Cashbox not found");
            }

            try
            {
                if (!NetworkInterface.GetIsNetworkAvailable())
                {
                    throw new NetworkException("No network connection available");
                }
                else if (cashbox.Balance < request.Amount)
                {
                    throw new InsufficientFundsException("Insufficient funds");
                }
                else if (request.Amount <= 0)
                {
                    throw new InvalidAmountException("Invalid amount");
                }
                else if (cashbox.IsActive == false)
                {
                    throw new CashboxIsNotActiveException("Cashbox is not active");
                }
                else
                {
                    cashbox.Balance += request.Amount;
                    await _unitOfWork.SaveChangesAsync(cancellationToken);
                }
            }
            catch (NetworkException)
            {
                
            }
            catch (InsufficientFundsException)
            {
            }
            catch (InvalidAmountException)
            {
            }
            catch (InvalidCurrencyException)
            {
            }
            catch (CashboxIsNotActiveException)
            {
            }
            catch (Exception)
            {
            }
        }
        
    }
}