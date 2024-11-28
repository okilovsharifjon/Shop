using OsonCommerce.Application.Features;
using OsonCommerce.Domain.Entities;
using MediatR;
using AutoMapper;
using OsonCommerce.Application.Interfaces.Repositories;

namespace OsonCommerce.Application.Features;

public class GetProductPriceByIdQueryHandler(
    IRepository<ProductPrice> repository,
    IMapper mapper
    ) : IRequestHandler<GetProductPriceByIdQuery, ProductPriceDto>
{
    private readonly IRepository<ProductPrice> _repository = repository;
    private readonly IMapper _mapper = mapper;

    public async Task<ProductPriceDto> Handle(GetProductPriceByIdQuery request, CancellationToken cancellationToken)
    {
        var productPrice = await _repository.GetByIdAsNoTrackingAsync(request.Id, cancellationToken);
        return _mapper.Map<ProductPriceDto>(productPrice);
    }
}