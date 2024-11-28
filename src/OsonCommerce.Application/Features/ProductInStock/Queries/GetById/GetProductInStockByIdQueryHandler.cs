using MediatR;
using AutoMapper;
using OsonCommerce.Domain.Entities;
using OsonCommerce.Application.Interfaces.Repositories;

namespace OsonCommerce.Application.Features;

public class GetProductInStockByIdQueryHandler(
    IRepository<ProductInStock> repository, 
    IMapper mapper
    ) : IRequestHandler<GetProductInStockByIdQuery, ProductInStockDto>
{
    private readonly IRepository<ProductInStock> _repository = repository;
    private readonly IMapper _mapper = mapper;

    public async Task<ProductInStockDto> Handle(GetProductInStockByIdQuery request, CancellationToken cancellationToken)
    {
        var productInStock = await _repository.GetByIdAsNoTrackingAsync(request.Id, cancellationToken);
        return _mapper.Map<ProductInStockDto>(productInStock);
    }
}
