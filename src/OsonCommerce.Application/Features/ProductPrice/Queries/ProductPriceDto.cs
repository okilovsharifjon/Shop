﻿using AutoMapper;
using OsonCommerce.Application.Common.Mappers;
using OsonCommerce.Domain.Entities;

namespace OsonCommerce.Application.Features;

public class ProductPriceDto : IMapWith<ProductPrice>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<ProductPrice, ProductPriceDto>();
    }
}