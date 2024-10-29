using MediatR;

namespace CatalogService.Application.UseCases
{
    public class DeleteCashboxCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}

