using MediatR;

namespace OsonCommerce.Application.Features;

public class UpdateStoreBranchCommand : IRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public string Manager { get; set; }
    public bool IsActive { get; set; }
} 