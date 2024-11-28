using OsonCommerce.Application.Features;
using OsonCommerce.Domain.Entities;
using MediatR;
using AutoMapper;
using OsonCommerce.Application.Interfaces.Repositories;

namespace OsonCommerce.Application.Features;

public class GetProductAttributeByIdQueryHandler(
    IRepository<ProductAttribute> repository,
    IMapper mapper
    ) : IRequestHandler<GetProductAttributeByIdQuery, ProductAttributeDto>
{
    private readonly IRepository<ProductAttribute> _repository = repository;
    private readonly IMapper _mapper = mapper;

    public async Task<ProductAttributeDto> Handle(GetProductAttributeByIdQuery request, CancellationToken cancellationToken)
    {
        var productAttribute = await _repository.GetByIdAsNoTrackingAsync(request.Id, cancellationToken);
        return _mapper.Map<ProductAttributeDto>(productAttribute);
    }
}