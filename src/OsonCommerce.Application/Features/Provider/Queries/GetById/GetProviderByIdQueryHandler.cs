using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using OsonCommerce.Domain.Entities;
using OsonCommerce.Application.Common.Exceptions;
using OsonCommerce.Application.Interfaces.Repositories;

namespace OsonCommerce.Application.Features;

public class GetProviderByIdQueryHandler(
    IRepository<Provider> repository, 
    IMapper mapper
    ) : IRequestHandler<GetProviderByIdQuery, ProviderDto>
{
    private readonly IRepository<Provider> _repository = repository;
    private readonly IMapper _mapper = mapper;

    public async Task<ProviderDto> Handle(GetProviderByIdQuery request, CancellationToken cancellationToken)
    {
        var provider = await _repository.GetByIdAsNoTrackingAsync(request.Id, cancellationToken);
        if (provider == null)
        {
            throw new NotFoundException("Provider not found");
        }

        return _mapper.Map<ProviderDto>(provider);
    }
}

