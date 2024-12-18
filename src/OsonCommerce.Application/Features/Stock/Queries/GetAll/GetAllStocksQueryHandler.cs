using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using OsonCommerce.Domain.Entities;
using OsonCommerce.Application.Interfaces.Repositories;

namespace OsonCommerce.Application.Features;

public class GetAllStocksQueryHandler(
    IRepository<Stock> repository, 
    IMapper mapper
    ) : IRequestHandler<GetAllStocksQuery, List<StockDto>>
{
    private readonly IRepository<Stock> _repository = repository;
    private readonly IMapper _mapper = mapper;

    public async Task<List<StockDto>> Handle(GetAllStocksQuery request, CancellationToken cancellationToken)
    {
        var stocks = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<List<StockDto>>(stocks);
    }
}

