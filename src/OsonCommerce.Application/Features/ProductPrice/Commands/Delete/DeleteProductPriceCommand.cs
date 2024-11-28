using MediatR;

namespace OsonCommerce.Application.Features;

public class DeleteProductPriceCommand : IRequest
{
    public Guid Id { get; set; }
}