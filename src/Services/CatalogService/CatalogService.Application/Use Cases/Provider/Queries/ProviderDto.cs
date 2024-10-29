using AutoMapper;
using CatalogService.Application.Mappers;
using CatalogService.Domain.Entities;
namespace CatalogService.Application.UseCases
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

