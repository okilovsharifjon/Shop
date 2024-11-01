using OsonCommerce.Application.Interfaces;
using OsonCommerce.Application.Features;
using OsonCommerce.Domain.Entities;
using MediatR;
using AutoMapper;

namespace OsonCommerce.Application.Features;

public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, List<CategoryDto>>
{
    private readonly IRepository<Category> _repository;
    private readonly IMapper _mapper;

    public GetAllCategoriesQueryHandler(IRepository<Category> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<CategoryDto>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<List<CategoryDto>>(categories);
    }
}