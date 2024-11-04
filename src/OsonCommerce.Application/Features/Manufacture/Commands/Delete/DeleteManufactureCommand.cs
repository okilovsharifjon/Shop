using MediatR;

namespace OsonCommerce.Application.Features;

public class DeleteManufactureCommand : IRequest
{
    public Guid Id { get; set; }
}