using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using OsonCommerce.Domain.Entities;
using OsonCommerce.Application.Exceptions;

namespace OsonCommerce.Application.Features
{
    public class GetProviderByIdQueryHandler : IRequestHandler<GetProviderByIdQuery, ProviderDto>
    {
        private readonly IRepository<Provider> _repository;
        private readonly IMapper _mapper;

        public GetProviderByIdQueryHandler(IRepository<Provider> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

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
}

