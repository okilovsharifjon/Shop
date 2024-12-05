namespace OsonCommerce.Domain.Entities;

public class Product
{
    public Guid Id { get; set; }
    public Guid? ManufactureId { get; set; }
    public Guid? CategoryId { get; set; }
    public ICollection<Guid> ProductAttributeIds { get; set; }
    public string Name { get; set; }
    public int? Unit { get; set; }
    public string? ImageName { get; set; }   
    public string? Description { get; set; } 
    public decimal? Weight { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime? ManufactureDate { get; set; }
    public DateTime? ExpiryDate { get; set; }
    public string SKU { get; set; }
    public Manufacture? Manufacture { get; set; }
    public ICollection<ProductInStock> ProductStocks { get; set; }
    public ICollection<ProductAttribute> ProductAttributes { get; set; }
    public ICollection<ProductPrice> ProductPrices { get; set; }
    public ICollection<OrderItem> OrderItems { get; set; }
}

