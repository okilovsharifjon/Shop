using AutoMapper;
using OsonCommerce.Application.Mappers;
using OsonCommerce.Domain.Entities;

namespace OsonCommerce.Application.Features;

public class ProductInStockDto : IMapWith<ProductInStock>
{
    public int ProductPriceID { get; set; }
    public int ProductID { get; set; }
    public int WarehouseID { get; set; }
    public int PriceTypeID { get; set; }
    public decimal Price { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<ProductInStock, ProductInStockDto>();
    }
}