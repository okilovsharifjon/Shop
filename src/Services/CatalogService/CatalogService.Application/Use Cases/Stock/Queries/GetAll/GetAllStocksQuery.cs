using MediatR;
using System.Collections.Generic;


namespace CatalogService.Application.UseCases
{
    public class GetAllStocksQuery : IRequest<List<StockDto>>
    {
    }
}

