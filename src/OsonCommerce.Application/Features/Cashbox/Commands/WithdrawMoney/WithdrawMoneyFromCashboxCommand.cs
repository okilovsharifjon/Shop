using MediatR;

namespace OsonCommerce.Application.Features
{
    public class WithdrawMoneyFromCashboxCommand : IRequest
    {
        public Guid CashboxId { get; set; }
        public decimal Amount { get; set; }
    }
}