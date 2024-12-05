namespace OsonCommerce.Domain.Entities;

public class Cashbox
{
    public Guid Id { get; set; }
    public string Name { get; set; }    
    public string Key { get; set; }
    public decimal Balance { get; set; }
    public int PaymentMethod { get; set; }
    public bool IsActive { get; set; }
    public bool IsMultiCurrency { get; set; }
    public DateTime LastUpdatedDate { get; set; }
    public ICollection<CashboxOperation> CashboxOperations { get; set; }
    public ICollection<Order> Orders { get; set; }
}
