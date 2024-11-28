using MediatR;

namespace OsonCommerce.Application.Features;

public class UpdateProductPriceCommand : IRequest
{
    public Guid ProductPriceID { get; set; }
    public Guid ProductID { get; set; }
    public Guid StockID { get; set; }
    public Guid PriceTypeID { get; set; }
    public decimal Price { get; set; }
}

