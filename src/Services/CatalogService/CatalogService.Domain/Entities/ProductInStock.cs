using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Domain.Entities
{
    public class ProductInStock
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid StockId { get; set; }
        public Guid ProviderId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }   
        public bool IsAvailable { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
