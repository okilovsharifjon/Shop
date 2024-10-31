using OsonCommerce.Domain.Enums;

namespace OsonCommerce.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public Guid? ManufactureId { get; set; }
        public Guid? CategoryId { get; set; }
        public string Name { get; set; }
        public Unit Unit { get; set; }
        public string ImageName { get; set; }   
        public string Description { get; set; } 
        public decimal Weight { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime ManufactureDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string SKU { get; set; }
        public Manufacture? Manufacture { get; set; }
        public List<ProductInStock> ProductStocks { get; set; } = new List<ProductInStock>();
        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<ProductAttribute> ProductAttributes { get; set; }
        public virtual ICollection<ProductPrice> ProductPrices { get; set; }
    }
    
}
