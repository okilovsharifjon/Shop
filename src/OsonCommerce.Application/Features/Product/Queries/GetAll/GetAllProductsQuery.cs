using MediatR;

namespace OsonCommerce.Application.Features
{
    public class GetAllProductsQuery : IRequest<List<ProductDto>>
    {
    }
}