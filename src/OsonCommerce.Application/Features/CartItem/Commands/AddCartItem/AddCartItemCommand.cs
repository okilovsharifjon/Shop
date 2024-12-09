﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsonCommerce.Application.Features
{
    public class AddCartItemCommand
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
