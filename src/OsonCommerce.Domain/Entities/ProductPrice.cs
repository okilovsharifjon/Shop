namespace OsonCommerce.Domain.Entities
{
    public class ProductPrice
    {
        public int ProductPriceID { get; set; }
        public int ProductID { get; set; }
        public int WarehouseID { get; set; }
        public int PriceTypeID { get; set; }
        public decimal Price { get; set; }

       public virtual Product Product { get; set; }
        public virtual Stock Stock { get; set; }
        public virtual PriceType PriceType { get; set; }
    }
}
