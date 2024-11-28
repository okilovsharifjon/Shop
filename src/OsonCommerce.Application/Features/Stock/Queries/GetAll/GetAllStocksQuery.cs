using MediatR;
using System.Collections.Generic;


namespace OsonCommerce.Application.Features;

public class GetAllStocksQuery : IRequest<List<StockDto>>
{
}

