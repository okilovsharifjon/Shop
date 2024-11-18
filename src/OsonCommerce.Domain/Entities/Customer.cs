using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsonCommerce.Domain.Entities
{
    public class Customer : User
    {
        public string ShippingAddress { get; set; } //todo: not finished online side
    }
}
