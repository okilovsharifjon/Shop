using MediatR;

namespace CatalogService.Application.UseCases
{
    public class GetProductByIdQuery : IRequest<ProductDto>
    {
        public Guid Id { get; set; }
    }
}