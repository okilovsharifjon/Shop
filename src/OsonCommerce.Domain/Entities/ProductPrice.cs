namespace OsonCommerce.Domain.Entities
{
    public class ProductPrice
    {
        public Guid ProductPriceID { get; set; }
        public Guid ProductID { get; set; }
        public Guid StockID { get; set; }
        public Guid PriceTypeID { get; set; }
        public decimal Price { get; set; }
        public virtual Product Product { get; set; }
        public virtual Stock Stock { get; set; }
        public virtual PriceType PriceType { get; set; }
    }
}
