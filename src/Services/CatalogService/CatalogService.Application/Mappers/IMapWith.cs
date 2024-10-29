using AutoMapper;

namespace CatalogService.Application.Mappers
{
    public interface IMapWith<T>
    {
        void Mapping(Profile profile) => 
            profile.CreateMap(typeof(T), GetType());
    }
}