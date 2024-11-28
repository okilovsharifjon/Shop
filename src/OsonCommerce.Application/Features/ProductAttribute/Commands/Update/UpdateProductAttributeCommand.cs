using MediatR;

namespace OsonCommerce.Application.Features;

public class UpdateProductAttributeCommand : IRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}

