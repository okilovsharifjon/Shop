using AutoMapper;

namespace OsonCommerce.Application.Mappers
{
    public interface IMapWith<T>
    {
        void Mapping(Profile profile) => 
            profile.CreateMap(typeof(T), GetType());
    }
}