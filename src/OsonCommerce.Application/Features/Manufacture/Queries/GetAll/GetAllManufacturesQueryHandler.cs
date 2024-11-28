using MediatR;
using AutoMapper;
using OsonCommerce.Domain.Entities;
using OsonCommerce.Application.Interfaces.Repositories;
namespace OsonCommerce.Application.Features;

public class GetAllManufacturesQueryHandler(
    IRepository<Manufacture> repository, 
    IMapper mapper
    ) : IRequestHandler<GetAllManufacturesQuery, List<ManufactureDto>>
{
    private readonly IRepository<Manufacture> _repository = repository;
    private readonly IMapper _mapper = mapper;

    public async Task<List<ManufactureDto>> Handle(GetAllManufacturesQuery request, CancellationToken cancellationToken)
    {
        var manufactures = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<List<ManufactureDto>>(manufactures);
    }
}