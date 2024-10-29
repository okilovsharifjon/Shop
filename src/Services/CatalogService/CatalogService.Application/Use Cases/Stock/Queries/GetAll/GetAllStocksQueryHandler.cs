using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using CatalogService.Domain.Entities;

namespace CatalogService.Application.UseCases
{
    public class GetAllStocksQueryHandler : IRequestHandler<GetAllStocksQuery, List<StockDto>>
    {
        private readonly IRepository<Stock> _repository;
        private readonly IMapper _mapper;

        public GetAllStocksQueryHandler(IRepository<Stock> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<StockDto>> Handle(GetAllStocksQuery request, CancellationToken cancellationToken)
        {
            var stocks = await _repository.GetAllAsync(cancellationToken);
            return _mapper.Map<List<StockDto>>(stocks);
        }
    }
}

