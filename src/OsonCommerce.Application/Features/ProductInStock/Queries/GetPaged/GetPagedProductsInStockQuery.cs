using MediatR;
using OsonCommerce.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsonCommerce.Application.Features;

public class GetPagedProductsInStockQuery : IRequest<PagedResult<ProductInStockDto>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
