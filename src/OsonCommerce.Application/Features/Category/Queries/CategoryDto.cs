using AutoMapper;
using OsonCommerce.Application.Mappers;
using OsonCommerce.Domain.Entities;

namespace OsonCommerce.Application.Features;

public class CategoryDto : IMapWith<Category>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Category, CategoryDto>();
    }
}