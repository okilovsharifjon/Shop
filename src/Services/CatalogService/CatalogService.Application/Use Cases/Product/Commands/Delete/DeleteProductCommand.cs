using MediatR;

namespace CatalogService.Application.UseCases
{
    public class DeleteProductCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}