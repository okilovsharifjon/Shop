using MediatR;

namespace CatalogService.Application.UseCases
{
    public class AddMoneyToCashboxCommand : IRequest
    {
        public Guid CashboxId { get; set; }
        public decimal Amount { get; set; }
    }
}


