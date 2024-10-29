using System;
using System.Collections.Generic;

namespace CatalogService.Domain.Entities
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
