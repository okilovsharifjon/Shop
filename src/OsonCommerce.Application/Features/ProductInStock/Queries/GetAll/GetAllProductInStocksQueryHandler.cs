using MediatR;
using AutoMapper;
using OsonCommerce.Application.Interfaces;
using OsonCommerce.Domain.Entities;

namespace OsonCommerce.Application.Features;

public class GetAllProductInStocksQueryHandler : IRequestHandler<GetAllProductInStocksQuery, List<ProductInStockDto>>
{
    private readonly IRepository<ProductInStock> _repository;
    private readonly IMapper _mapper;
    public GetAllProductInStocksQueryHandler(IRepository<ProductInStock> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<ProductInStockDto>> Handle(GetAllProductInStocksQuery request, CancellationToken cancellationToken)
    {
        var productInStocks = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<List<ProductInStockDto>>(productInStocks);
    }
}