using MediatR;
using AutoMapper;
using OsonCommerce.Domain.Entities;
using OsonCommerce.Application.Interfaces;
using OsonCommerce.Application.Exceptions;
namespace OsonCommerce.Application.Features;

public class GetManufactureByIdQueryHandler : IRequestHandler<GetManufactureByIdQuery, Manufacture>
{
    private readonly IRepository<Manufacture> _repository;
    private readonly IMapper _mapper;

    public GetManufactureByIdQueryHandler(IRepository<Manufacture> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

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