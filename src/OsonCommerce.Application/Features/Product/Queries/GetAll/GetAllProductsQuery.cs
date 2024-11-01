using MediatR;
using OsonCommerce.Application.Tools;

namespace OsonCommerce.Application.Features
{
    public class GetAllProductsQuery : IRequest<List<ProductDto>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}