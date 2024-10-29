using MediatR;

namespace CatalogService.Application.UseCases;

public class CreateCategoryCommand : IRequest<Guid>
{
    public string Name { get; set; }
    public string Description { get; set; }
}

