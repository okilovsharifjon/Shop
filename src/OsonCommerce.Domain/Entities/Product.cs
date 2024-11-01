using OsonCommerce.Domain.Enums;

namespace OsonCommerce.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public Guid? ManufactureId { get; set; }
        public Guid? CategoryId { get; set; }
        public Guid? ProductAttributeId { get; set; }
        public string Name { get; set; }
        public Unit Unit { get; set; }
        public string? ImageName { get; set; }   
        public string? Description { get; set; } 
        public decimal? Weight { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime ManufactureDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string SKU { get; set; }
        public Manufacture? Manufacture { get; set; }
        public ProductAttribute ProductAttribute { get; set; }
        public ICollection<ProductInStock> ProductStocks { get; set; }
        public virtual ICollection<Category> Categories { get; set; } //TODO: Ask about this
        public virtual ICollection<ProductAttribute> ProductAttributes { get; set; }
        public virtual ICollection<ProductPrice> ProductPrices { get; set; }
    }
    
}
