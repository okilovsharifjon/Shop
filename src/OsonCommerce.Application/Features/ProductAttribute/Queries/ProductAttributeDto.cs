using AutoMapper;
using OsonCommerce.Application.Common.Mappers;
using OsonCommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsonCommerce.Application.Features
{
    public class ProductAttributeDto : IMapWith<ProductAttribute>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ProductAttribute, ProductAttributeDto>();
        }
    }
}
