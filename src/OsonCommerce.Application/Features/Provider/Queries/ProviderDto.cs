using AutoMapper;
using OsonCommerce.Application.Mappers;
using OsonCommerce.Domain.Entities;

namespace OsonCommerce.Application.Features
{
    public class ProviderDto : IMapWith<Provider>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string ContactInfo { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Provider, ProviderDto>();
        }
    }
}

