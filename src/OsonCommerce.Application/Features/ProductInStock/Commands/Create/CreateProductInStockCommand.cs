using MediatR;
using OsonCommerce.Domain.Entities;

namespace OsonCommerce.Application.Features;

public class CreateProductInStockCommand : IRequest<Guid>
{
    public Guid ProductId { get; set; }
    public Guid ProductPriceId { get; set; }
    public Guid StockId { get; set; }
    public Guid ProviderId { get; set; }
    public int Quantity { get; set; }  
    public bool IsAvailable { get; set; }
}