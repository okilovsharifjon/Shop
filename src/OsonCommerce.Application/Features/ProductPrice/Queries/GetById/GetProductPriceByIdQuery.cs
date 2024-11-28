using MediatR;

namespace OsonCommerce.Application.Features;

public class GetProductPriceByIdQuery : IRequest<ProductPriceDto>
{
    public Guid Id { get; set; }
}

