namespace OsonCommerce.Domain.Entities;

public class OrderItem
{
    public Guid Id { get; set; }
    public Guid OrderId { get; set; }
    public Guid ProductId { get; set; }
    public Guid PriceId { get; set; } 
    public int Quantity { get; set; }
    public ProductPrice ProductPrice { get; set; }
    public Product Product { get; set; } 
} 