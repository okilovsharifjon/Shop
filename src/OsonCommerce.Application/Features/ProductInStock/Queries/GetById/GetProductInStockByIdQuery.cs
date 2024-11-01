using MediatR;

namespace OsonCommerce.Application.Features;

public class GetProductInStockByIdQuery : IRequest<ProductInStockDto>
{
    public Guid Id { get; set; }
}