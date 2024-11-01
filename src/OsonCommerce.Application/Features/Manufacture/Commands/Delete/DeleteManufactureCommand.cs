using MediatR;

namespace OsonCommerce.Application.Features;

public class DeleteManufactureCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
}