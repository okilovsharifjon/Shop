using MediatR;

namespace OsonCommerce.Application.Features;

public class CreateProductAttributeCommand : IRequest<Guid>
{
    public string Name { get; set; }
}