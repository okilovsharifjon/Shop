using AutoMapper;
using OsonCommerce.Domain.Entities;
using OsonCommerce.Application.Mappers;

namespace OsonCommerce.Application.Features;

public class ManufactureDto : IMapWith<Manufacture>
{
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LogoName { get; set; }
        public string WebsiteUrl { get; set; }
        public string CountryOfOrigin { get; set; }
        public bool IsActive { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Manufacture, ManufactureDto>();
    }
}
