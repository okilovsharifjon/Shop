using MediatR;

namespace OsonCommerce.Application.Features
{
    public class DeleteCashboxCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}

