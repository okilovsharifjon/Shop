using AutoMapper;
using MediatR;
using OsonCommerce.Domain.Entities;
using OsonCommerce.Application.Interfaces.Repositories;
using OsonCommerce.Application.Common.Models;

namespace OsonCommerce.Application.Features;

public class GetPagedProductsQueryHandler(
    IProductRepository repository, 
    IMapper mapper
    ) : IRequestHandler<GetPagedProductsQuery, PagedResult<ProductDto>>
{
    private readonly IProductRepository _repository = repository;
    private readonly IMapper _mapper = mapper;

    public async Task<PagedResult<ProductDto>> Handle(GetPagedProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _repository.GetPagedAsync(request.PageNumber, request.PageSize);
        var totalCount = await _repository.GetTotalCountAsync(cancellationToken);
        var productsDto = _mapper.Map<List<ProductDto>>(products);
        return new PagedResult<ProductDto> 
        { 
            Items = productsDto,
            TotalCount = totalCount,
            CurrentPage = request.PageNumber,
            PageSize = request.PageSize
        };
    }
}
