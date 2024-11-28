using OsonCommerce.Application.Features;
using OsonCommerce.Domain.Entities;
using MediatR;
using AutoMapper;
using OsonCommerce.Application.Interfaces.Repositories;

namespace OsonCommerce.Application.Features;

public class GetAllCategoriesQueryHandler(
    IRepository<Category> repository, 
    IMapper mapper
    ) : IRequestHandler<GetAllCategoriesQuery, List<CategoryDto>>
{
    private readonly IRepository<Category> _repository = repository;
    private readonly IMapper _mapper = mapper;

    public async Task<List<CategoryDto>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<List<CategoryDto>>(categories);
    }
}