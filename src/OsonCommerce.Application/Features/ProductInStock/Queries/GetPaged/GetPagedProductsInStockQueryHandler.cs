﻿using AutoMapper;
using MediatR;
using OsonCommerce.Application.Interfaces.Repositories;
using OsonCommerce.Application.Models;
using OsonCommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsonCommerce.Application.Features
{
    public class GetPagedProductsInStockQueryHandler : IRequestHandler<GetPagedProductsInStockQuery, PagedResult<ProductInStockDto>>
    {
        private readonly IRepository<ProductInStock> _repository;
        private readonly IMapper _mapper;

        public GetPagedProductsInStockQueryHandler(IRepository<ProductInStock> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PagedResult<ProductInStockDto>> Handle(GetPagedProductsInStockQuery request, CancellationToken cancellationToken)
        {
            var products = await _repository.GetPagedAsync(request.PageNumber, request.PageSize);
            var totalCount = await _repository.GetTotalCountAsync(cancellationToken);
            var productsDto = _mapper.Map<List<ProductInStockDto>>(products);
            return new PagedResult<ProductInStockDto>
            {
                Items = productsDto,
                TotalCount = totalCount,
                CurrentPage = request.PageNumber,
                PageSize = request.PageSize
            };
        }
    }
}