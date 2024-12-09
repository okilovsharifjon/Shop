using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsonCommerce.Domain.Entities
{
    public abstract class Cart
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; } 
        public int CartStatus { get; set; } = 1;
        public decimal TotalAmount { get; set; }
        public ICollection<CartItem> Items { get; set; } = new List<CartItem>();
        public Customer Customer { get; set; }
    }
}