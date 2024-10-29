using MediatR;
using System.Collections.Generic;
using CatalogService.Application.UseCases;

namespace CatalogService.Application.UseCases
{
    public class GetAllCashboxesQuery : IRequest<List<CashboxDto>>
    {
    }
}

