using MediatR;
using OsonCommerce.Application.Tools;

namespace OsonCommerce.Application.Features;

public class GetPagedProductsQuery : IRequest<PagedResult<ProductDto>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
