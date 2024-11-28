using MediatR;

namespace OsonCommerce.Application.Features;

public class CreateProductPriceCommand : IRequest<Guid>
{
    public Guid ProductID { get; set; }
    public Guid StockID { get; set; }
    public Guid PriceTypeID { get; set; }
    public Guid? ProductPriceId { get; set; }
    public decimal Price { get; set; }
}