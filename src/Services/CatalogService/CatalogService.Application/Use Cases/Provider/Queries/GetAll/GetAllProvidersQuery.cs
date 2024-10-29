using MediatR;
using System.Collections.Generic;

namespace CatalogService.Application.UseCases
{
    public class GetAllProvidersQuery : IRequest<List<ProviderDto>>
    {
    }
}

