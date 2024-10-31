using MediatR;
using System.Collections.Generic;

namespace OsonCommerce.Application.Features
{
    public class GetAllCashboxesQuery : IRequest<List<CashboxDto>>
    {
    }
}

