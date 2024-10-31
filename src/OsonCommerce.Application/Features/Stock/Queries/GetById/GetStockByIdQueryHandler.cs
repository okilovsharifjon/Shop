using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using OsonCommerce.Domain.Entities;
using OsonCommerce.Application.Exceptions;


namespace OsonCommerce.Application.Features
{
    public class GetStockByIdQueryHandler : IRequestHandler<GetStockByIdQuery, StockDto>
    {
        private readonly IRepository<Stock> _repository;
        private readonly IMapper _mapper;

        public GetStockByIdQueryHandler(IRepository<Stock> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<StockDto> Handle(GetStockByIdQuery request, CancellationToken cancellationToken)
        {
            var stock = await _repository.GetByIdAsNoTrackingAsync(request.Id, cancellationToken);
            if (stock == null)
            {
                throw new NotFoundException("Stock not found");
            }

            return _mapper.Map<StockDto>(stock);
        }
    }
}

