using MediatR;
using AutoMapper;
using OsonCommerce.Application.Interfaces;
using OsonCommerce.Domain.Entities;

namespace OsonCommerce.Application.Features;

public class GetProductInStockByIdQueryHandler : IRequestHandler<GetProductInStockByIdQuery, ProductInStockDto>
{
    private readonly IRepository<ProductInStock> _repository;
    private readonly IMapper _mapper;

    public GetProductInStockByIdQueryHandler(IRepository<ProductInStock> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ProductInStockDto> Handle(GetProductInStockByIdQuery request, CancellationToken cancellationToken)
    {
        var productInStock = await _repository.GetByIdAsNoTrackingAsync(request.Id, cancellationToken);
        return _mapper.Map<ProductInStockDto>(productInStock);
    }
}
