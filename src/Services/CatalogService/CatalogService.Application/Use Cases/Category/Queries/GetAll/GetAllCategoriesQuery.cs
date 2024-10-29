using MediatR;

namespace CatalogService.Application.UseCases;

public class GetAllCategoriesQuery : IRequest<List<CategoryDto>>
{
}

