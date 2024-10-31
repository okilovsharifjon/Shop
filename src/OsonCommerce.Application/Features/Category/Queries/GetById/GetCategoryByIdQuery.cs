using MediatR;

namespace OsonCommerce.Application.Features;

public class GetCategoryByIdQuery : IRequest<CategoryDto>
{
    public Guid Id { get; set; }
}

    