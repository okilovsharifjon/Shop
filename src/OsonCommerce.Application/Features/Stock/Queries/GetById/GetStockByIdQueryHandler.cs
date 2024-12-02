using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using OsonCommerce.Domain.Entities;
using OsonCommerce.Application.Common.Exceptions;
using OsonCommerce.Application.Interfaces.Repositories;


namespace OsonCommerce.Application.Features;

public class GetStockByIdQueryHandler(
    IRepository<Stock> repository, 
    IMapper mapper
    ) : IRequestHandler<GetStockByIdQuery, StockDto>
{
    private readonly IRepository<Stock> _repository = repository;
    private readonly IMapper _mapper = mapper;

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

