using MediatR;

namespace OsonCommerce.Application.Features;

public class DeleteProductAttributeCommand : IRequest
{
    public Guid Id { get; set; }
}