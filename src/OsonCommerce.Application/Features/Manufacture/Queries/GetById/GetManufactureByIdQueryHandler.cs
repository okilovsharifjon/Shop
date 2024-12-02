using MediatR;
using AutoMapper;
using OsonCommerce.Domain.Entities;
using OsonCommerce.Application.Common.Exceptions;
using OsonCommerce.Application.Interfaces.Repositories;
namespace OsonCommerce.Application.Features;

public class GetManufactureByIdQueryHandler(
    IRepository<Manufacture> repository, 
    IMapper mapper
    ) : IRequestHandler<GetManufactureByIdQuery, ManufactureDto>
{
    private readonly IRepository<Manufacture> _repository = repository;
    private readonly IMapper _mapper = mapper;

    public async Task<ManufactureDto> Handle(GetManufactureByIdQuery request, CancellationToken cancellationToken)
    {
        var manufacture = await _repository.GetByIdAsNoTrackingAsync(request.Id, cancellationToken);
        if (manufacture == null)
        {
            throw new NotFoundException("Manufacture not found");
        }
        return _mapper.Map<ManufactureDto>(manufacture);
    }
}