using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatalogService.Domain.Entities;
using CatalogService.Domain;
using CatalogService.Domain.Enums;

namespace CatalogService.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public Guid? BrandId { get; set; }
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
        public Brand? Brand { get; set; }
        public List<ProductInStock> ProductStocks { get; set; } = new List<ProductInStock>();
        
    }
    
}
