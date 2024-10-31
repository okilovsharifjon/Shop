using MediatR;

namespace OsonCommerce.Application.Features;

public class DeleteCategoryCommand : IRequest
{
    public Guid Id { get; set; }
}