using MediatR;

namespace CatalogService.Application.UseCases;

public class GetCategoryByIdQuery : IRequest<CategoryDto>
{
    public Guid Id { get; set; }
}

    