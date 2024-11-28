using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using OsonCommerce.Domain.Entities;
using OsonCommerce.Application.Interfaces.Repositories;

namespace OsonCommerce.Application.Features;

public class GetAllCashboxesQueryHandler(
    ICashboxRepository repository, 
    IMapper mapper
    ) : IRequestHandler<GetAllCashboxesQuery, List<CashboxDto>>
{
    private readonly ICashboxRepository _repository = repository;
    private readonly IMapper _mapper = mapper;

    public async Task<List<CashboxDto>> Handle(GetAllCashboxesQuery request, CancellationToken cancellationToken)
    {
        var cashboxes = await _repository.GetAllAsync(cancellationToken);
        return cashboxes.Select(c => _mapper.Map<CashboxDto>(c)).ToList();
    }
    
}

