using MediatR;
using System.Collections.Generic;

namespace OsonCommerce.Application.Features
{
    public class GetAllProductsQuery : IRequest<List<ProductDto>>
    {
    }
}