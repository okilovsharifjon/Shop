using MediatR;

namespace OsonCommerce.Application.Features;

public class UpdatePriceTypeCommand : IRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}

