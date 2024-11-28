using MediatR;

namespace OsonCommerce.Application.Features;

public class GetStockByIdQuery : IRequest<StockDto>
{
    public Guid Id { get; set; }
}

