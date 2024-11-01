using AutoMapper;
using MediatR;
using OsonCommerce.Domain.Entities;
using OsonCommerce.Application.Interfaces;
using OsonCommerce.Application.Tools;
namespace OsonCommerce.Application.Features
{
    public class GetPagedProductsQueryHandler : IRequestHandler<GetPagedProductsQuery, PagedResult<ProductDto>>
    {
        private readonly IRepository<Product> _repository;
        private readonly IMapper _mapper;

        public GetPagedProductsQueryHandler(IRepository<Product> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

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
}
