using MediatR;

namespace OsonCommerce.Application.Features;

public class CreateStoreBranchCommand : IRequest<Guid>
{
    public string Name { get; set; }
    public ICollection<Guid> ManagerIds { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public bool IsActive { get; set; }
    public string OperatingHours { get; set; }
} 