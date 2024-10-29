using MediatR;

namespace CatalogService.Application.UseCases
{
    public class GetCashboxByIdQuery : IRequest<CashboxDto>
    {
        public Guid Id { get; set; }
    }
}

