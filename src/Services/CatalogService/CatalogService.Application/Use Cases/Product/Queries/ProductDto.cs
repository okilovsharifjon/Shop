using AutoMapper;
using CatalogService.Application.Mappers;
using CatalogService.Domain.Entities;
namespace CatalogService.Application.UseCases
{
    public class ProductDto : IMapWith<Product>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid BrandId { get; set; }
        public Guid? CategoryId { get; set; }
        public Domain.Enums.Unit Unit { get; set; }
        public string ImageName { get; set; }
        public string Description { get; set; }
        public decimal Weight { get; set; }
        public DateTime ManufactureDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string SKU { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Product, ProductDto>();
        }
    }
}