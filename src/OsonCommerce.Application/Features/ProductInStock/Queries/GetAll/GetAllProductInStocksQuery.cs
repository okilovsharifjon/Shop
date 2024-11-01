using MediatR;

namespace OsonCommerce.Application.Features
{
    public class GetAllProductInStocksQuery : IRequest<List<ProductInStockDto>>
    {
    }   
}