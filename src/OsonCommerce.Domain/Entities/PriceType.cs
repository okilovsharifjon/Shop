namespace OsonCommerce.Domain.Entities;

public class PriceType
{
    public Guid PriceTypeID { get; set; }
    public string Name { get; set; } 
    public string Description { get; set; }

    public virtual ICollection<ProductPrice> ProductPrices { get; set; }
}
