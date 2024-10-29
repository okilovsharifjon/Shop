using MediatR;

namespace CatalogService.Application.UseCases
{
    public class DeleteProviderCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}

