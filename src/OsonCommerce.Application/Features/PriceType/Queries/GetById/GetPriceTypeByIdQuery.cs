using MediatR;

namespace OsonCommerce.Application.Features;

public class GetPriceTypeByIdQuery : IRequest<PriceTypeDto>
{
    public Guid Id { get; set; }
}

