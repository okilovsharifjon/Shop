using MediatR;

namespace OsonCommerce.Application.Features;

public class DeletePriceTypeCommand : IRequest
{
    public Guid Id { get; set; }
}