using MediatR;
using System.Collections.Generic;

namespace CatalogService.Application.UseCases
{
    public class GetAllProductsQuery : IRequest<List<ProductDto>>
    {
    }
}