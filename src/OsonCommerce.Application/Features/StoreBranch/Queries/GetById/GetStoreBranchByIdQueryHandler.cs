using MediatR;
using AutoMapper;
using OsonCommerce.Domain.Entities;
using OsonCommerce.Application.Exceptions;
using OsonCommerce.Application.Interfaces.Repositories;

namespace OsonCommerce.Application.Features;

public class GetStoreBranchByIdQueryHandler : IRequestHandler<GetStoreBranchByIdQuery, StoreBranchDto>
{
    private readonly IRepository<StoreBranch> _repository;
    private readonly IMapper _mapper;

    public GetStoreBranchByIdQueryHandler(IRepository<StoreBranch> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<StoreBranchDto> Handle(GetStoreBranchByIdQuery request, CancellationToken cancellationToken)
    {
        var storeBranch = await _repository.GetByIdAsNoTrackingAsync(request.Id, cancellationToken);
        if (storeBranch == null)
        {
            throw new NotFoundException("StoreBranch not found");
        }

        return _mapper.Map<StoreBranchDto>(storeBranch);
    }
} 