using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using OsonCommerce.Domain.Entities;

namespace OsonCommerce.Application.Features
{
    public class GetAllCashboxesQueryHandler : IRequestHandler<GetAllCashboxesQuery, List<CashboxDto>>
    {
        private readonly IRepository<Cashbox> _repository;
        private readonly IMapper _mapper;
        public GetAllCashboxesQueryHandler(IRepository<Cashbox> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<CashboxDto>> Handle(GetAllCashboxesQuery request, CancellationToken cancellationToken)
        {
            var cashboxes = await _repository.GetAllAsync(cancellationToken);
            return cashboxes.Select(c => _mapper.Map<CashboxDto>(c)).ToList();
        }
        
    }
}

