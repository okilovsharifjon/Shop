using MediatR;
using OsonCommerce.Domain.Entities;
using OsonCommerce.Application.Exceptions;
using System.Net.NetworkInformation;
using FluentValidation;
using OsonCommerce.Application.Interfaces;

namespace OsonCommerce.Application.Features
{
    public class WithdrawMoneyCommandHandler : IRequestHandler<WithdrawMoneyCommand>
    {
        private readonly IRepository<Cashbox> _repository;
        private readonly IValidator<WithdrawMoneyCommand> _validator;
        private readonly IUnitOfWork _unitOfWork;
        
        public WithdrawMoneyCommandHandler(IRepository<Cashbox> repository, IValidator<WithdrawMoneyCommand> validator, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _validator = validator;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(WithdrawMoneyCommand request, CancellationToken cancellationToken)
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
                    cashbox.Balance -= request.Amount;
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