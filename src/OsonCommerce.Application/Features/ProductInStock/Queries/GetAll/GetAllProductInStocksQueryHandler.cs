using MediatR;
using AutoMapper;
using OsonCommerce.Domain.Entities;
using OsonCommerce.Application.Interfaces.Repositories;

namespace OsonCommerce.Application.Features;

public class GetAllProductInStocksQueryHandler(
    IRepository<ProductInStock> repository, 
    IMapper mapper
    ) : IRequestHandler<GetAllProductInStocksQuery, List<ProductInStockDto>>
{
    private readonly IRepository<ProductInStock> _repository = repository;
    private readonly IMapper _mapper = mapper;

    public async Task<List<ProductInStockDto>> Handle(GetAllProductInStocksQuery request, CancellationToken cancellationToken)
    {
        var productInStocks = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<List<ProductInStockDto>>(productInStocks);
    }
}