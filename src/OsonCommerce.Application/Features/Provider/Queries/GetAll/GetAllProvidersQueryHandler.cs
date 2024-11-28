using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using OsonCommerce.Domain.Entities;
using OsonCommerce.Application.Interfaces.Repositories;

namespace OsonCommerce.Application.Features;

public class GetAllProvidersQueryHandler(
    IRepository<Provider> repository, 
    IMapper mapper
    ) : IRequestHandler<GetAllProvidersQuery, List<ProviderDto>>
{
    private readonly IRepository<Provider> _repository = repository;
    private readonly IMapper _mapper = mapper;

    public async Task<List<ProviderDto>> Handle(GetAllProvidersQuery request, CancellationToken cancellationToken)
    {
        var providers = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<List<ProviderDto>>(providers);
}
}

