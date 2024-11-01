using MediatR;

namespace OsonCommerce.Application.Features;

public class GetStoreBranchByIdQuery : IRequest<StoreBranchDto>
{
    public Guid Id { get; set; }
} 