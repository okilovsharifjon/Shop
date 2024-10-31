using MediatR;

namespace OsonCommerce.Application.Features
{
    public class GetCashboxByIdQuery : IRequest<CashboxDto>
    {
        public Guid Id { get; set; }
    }
}

