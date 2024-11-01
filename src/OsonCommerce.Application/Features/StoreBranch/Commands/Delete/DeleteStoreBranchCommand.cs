using MediatR;

namespace OsonCommerce.Application.Features;

public class DeleteStoreBranchCommand : IRequest
{
    public Guid Id { get; set; }
} 