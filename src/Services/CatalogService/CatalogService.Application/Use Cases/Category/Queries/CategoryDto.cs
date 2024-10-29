using AutoMapper;
using CatalogService.Application.Mappers;
using CatalogService.Domain.Entities;

namespace CatalogService.Application.UseCases;

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