using MediatR;

namespace OsonCommerce.Application.Features;

public class GetProductByIdQuery : IRequest<ProductDto>
{
    public Guid Id { get; set; }
}