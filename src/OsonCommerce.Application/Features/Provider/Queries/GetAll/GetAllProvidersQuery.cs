using MediatR;
using System.Collections.Generic;

namespace OsonCommerce.Application.Features
{
    public class GetAllProvidersQuery : IRequest<List<ProviderDto>>
    {
    }
}

