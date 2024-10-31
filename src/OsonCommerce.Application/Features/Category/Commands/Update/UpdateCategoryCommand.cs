using MediatR;

namespace OsonCommerce.Application.Features;

public class UpdateCategoryCommand : IRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}

