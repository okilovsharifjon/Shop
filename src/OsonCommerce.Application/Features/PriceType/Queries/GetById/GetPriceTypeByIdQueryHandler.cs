using OsonCommerce.Application.Features;
using OsonCommerce.Domain.Entities;
using MediatR;
using AutoMapper;
using OsonCommerce.Application.Interfaces.Repositories;

namespace OsonCommerce.Application.Features;

public class GetPriceTypeByIdQueryHandler(
    IRepository<PriceType> repository,
    IMapper mapper
    ) : IRequestHandler<GetPriceTypeByIdQuery, PriceTypeDto>
{
    private readonly IRepository<PriceType> _repository = repository;
    private readonly IMapper _mapper = mapper;

    public async Task<PriceTypeDto> Handle(GetPriceTypeByIdQuery request, CancellationToken cancellationToken)
    {
        var priceType = await _repository.GetByIdAsNoTrackingAsync(request.Id, cancellationToken);
        return _mapper.Map<PriceTypeDto>(priceType);
    }
}