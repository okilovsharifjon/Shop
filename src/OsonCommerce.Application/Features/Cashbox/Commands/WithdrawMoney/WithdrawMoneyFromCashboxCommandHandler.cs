using MediatR;
using OsonCommerce.Domain.Entities;
using OsonCommerce.Application.Exceptions;
using System.Net.NetworkInformation;
using FluentValidation;
using OsonCommerce.Application.Interfaces;
using OsonCommerce.Domain.Enums;
using OsonCommerce.Application.Interfaces.Repositories;

namespace OsonCommerce.Application.Features
{
    public class WithdrawMoneyFromCashboxCommandHandler : IRequestHandler<WithdrawMoneyFromCashboxCommand>
    {
        private readonly IRepository<Cashbox> _cahboxRepository;
        private readonly IRepository<CashboxOperation> _operationRepository;
        private readonly IValidator<WithdrawMoneyFromCashboxCommand> _validator;
        private readonly IUnitOfWork _unitOfWork;
        
        public WithdrawMoneyFromCashboxCommandHandler(IRepository<Cashbox> cahboxRepository, IRepository<CashboxOperation> operationRepository, IUnitOfWork unitOfWork, IValidator<WithdrawMoneyFromCashboxCommand> validator)
        {
            _cahboxRepository = cahboxRepository;
            _operationRepository = operationRepository;
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task Handle(WithdrawMoneyFromCashboxCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAsync(request, cancellationToken);

            var cashbox = await _cahboxRepository.GetByIdAsync(request.CashboxId, cancellationToken);
            if (cashbox == null)
            {
                throw new NotFoundException("Cashbox not found");
            }

            var operation = new CashboxOperation
            {
                Id = Guid.NewGuid(),
                Amount = request.Amount,
                CashboxId = request.CashboxId,
                Date = DateTime.Now,
                Description = "description",
                Status = TransactionStatus.Failed,
                TransactionType = TransactionType.Withdrawal
            };

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
                    await _unitOfWork.SaveChangesAsync();
                    operation.Status = TransactionStatus.Completed;
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