using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using OsonCommerce.Domain.Entities;
using OsonCommerce.Application.Exceptions;


namespace OsonCommerce.Application.Features
{
    public class GetCashboxByIdQueryHandler : IRequestHandler<GetCashboxByIdQuery, CashboxDto>
    {
        private readonly IRepository<Cashbox> _repository;
        private readonly IMapper _mapper;

        public GetCashboxByIdQueryHandler(IRepository<Cashbox> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CashboxDto> Handle(GetCashboxByIdQuery request, CancellationToken cancellationToken)
        {
            var cashbox = await _repository.GetByIdAsNoTrackingAsync(request.Id, cancellationToken);
            if (cashbox == null)
            {
                throw new NotFoundException("Cashbox not found");
            }

            return _mapper.Map<CashboxDto>(cashbox);
        }
    }
}
