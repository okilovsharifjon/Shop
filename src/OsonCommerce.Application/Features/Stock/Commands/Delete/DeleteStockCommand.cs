using MediatR;

namespace OsonCommerce.Application.Features;

public class DeleteStockCommand : IRequest
{
    public Guid Id { get; set; }
}

