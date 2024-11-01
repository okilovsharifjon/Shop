using MediatR;

namespace OsonCommerce.Application.Features;

public class CreateCategoryCommand : IRequest<Guid>
{
    public string Name { get; set; }
    public string Description { get; set; }
}

