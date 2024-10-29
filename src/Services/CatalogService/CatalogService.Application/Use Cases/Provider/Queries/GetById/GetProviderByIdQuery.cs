using MediatR;

namespace CatalogService.Application.UseCases
{
    public class GetProviderByIdQuery : IRequest<ProviderDto>
    {
        public Guid Id { get; set; }
    }
}

