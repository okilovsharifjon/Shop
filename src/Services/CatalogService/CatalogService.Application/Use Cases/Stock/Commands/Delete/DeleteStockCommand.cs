using MediatR;

namespace CatalogService.Application.UseCases
{
    public class DeleteStockCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}

