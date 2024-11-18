using OsonCommerce.Application.Features;
using OsonCommerce.Domain.Entities;
using MediatR;
using AutoMapper;
using OsonCommerce.Application.Interfaces.Repositories;

namespace OsonCommerce.Application.Features;

public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, CategoryDto>
{
    private readonly IRepository<Category> _repository;
    private readonly IMapper _mapper;

    public GetCategoryByIdQueryHandler(IRepository<Category> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<CategoryDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var category = await _repository.GetByIdAsNoTrackingAsync(request.Id, cancellationToken);
        return _mapper.Map<CategoryDto>(category);
    }
}