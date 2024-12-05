namespace OsonCommerce.Domain.Entities;

public class Order
{
    public Guid Id { get; set; }
    public Guid? CustomerId { get; set; }
    public Guid? CashboxId { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }
    public int PaymentMethod { get; set; }
    public int Status { get; set; } 
    public ICollection<OrderItem> OrderItems { get; set; } // Список товаров в заказе
} 
