using MediatR;

namespace OsonCommerce.Application.Features;

public class GetProductAttributeByIdQuery : IRequest<ProductAttributeDto>
{
    public Guid Id { get; set; }
}

