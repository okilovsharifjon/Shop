using OsonCommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsonCommerce.Application.Features
{
    public class CreateCartCommand
    {
        public Guid UserId { get; set; }
        public bool IsTemporary { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
