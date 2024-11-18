using AutoMapper;
using MediatR;
using OsonCommerce.Domain.Entities;
using OsonCommerce.Application.Interfaces.Repositories;

namespace OsonCommerce.Application.Features
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<ProductDto>>
    {
        private readonly IRepository<Product> _repository;
        private readonly IMapper _mapper;

        public GetAllProductsQueryHandler(IRepository<Product> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _repository.GetAllAsync(cancellationToken);
            return _mapper.Map<List<ProductDto>>(products);
        }
    }
}
