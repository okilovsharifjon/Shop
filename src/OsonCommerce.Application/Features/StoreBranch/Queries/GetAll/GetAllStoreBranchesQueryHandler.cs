using MediatR;
using AutoMapper;
using OsonCommerce.Domain.Entities;
using System.Collections.Generic;
using OsonCommerce.Application.Interfaces.Repositories;

namespace OsonCommerce.Application.Features;

public class GetAllStoreBranchesQueryHandler : IRequestHandler<GetAllStoreBranchesQuery, List<StoreBranchDto>>
{
    private readonly IRepository<StoreBranch> _repository;
    private readonly IMapper _mapper;

    public GetAllStoreBranchesQueryHandler(IRepository<StoreBranch> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<StoreBranchDto>> Handle(GetAllStoreBranchesQuery request, CancellationToken cancellationToken)
    {
        var storeBranches = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<List<StoreBranchDto>>(storeBranches);
    }
} 