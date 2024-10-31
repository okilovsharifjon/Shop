using MediatR;

namespace OsonCommerce.Application.Features;

public class GetAllCategoriesQuery : IRequest<List<CategoryDto>>
{
}

