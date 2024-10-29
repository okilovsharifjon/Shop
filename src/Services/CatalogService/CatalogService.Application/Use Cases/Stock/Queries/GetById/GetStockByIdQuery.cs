using MediatR;

namespace CatalogService.Application.UseCases
{
    public class GetStockByIdQuery : IRequest<StockDto>
    {
        public Guid Id { get; set; }
    }
}

