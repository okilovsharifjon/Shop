using MediatR;

namespace OsonCommerce.Application.Features;

public class DeleteProviderCommand : IRequest
{
    public Guid Id { get; set; }
}

