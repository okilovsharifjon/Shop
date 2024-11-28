namespace OsonCommerce.Domain.Entities;

public class ProductInStock
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public Guid StockId { get; set; }
    public Guid ProviderId { get; set; }
    public int? Quantity { get; set; }
    public bool IsAvailable { get; set; }
    public DateTime LastUpdated { get; set; }
    public Guid ProductPriceId { get; set; }
    public virtual ProductPrice ProductPrice { get; set; }
    public virtual Stock Stock { get; set; }
    public virtual Provider Provider { get; set; }
    public virtual Product Product { get; set; }
}
