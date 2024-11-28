using AutoMapper;
using OsonCommerce.Domain.Entities;
using OsonCommerce.Application.Common.Mappers;

namespace OsonCommerce.Application.Features;

public class CashboxDto : IMapWith<Cashbox>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Key { get; set; }
    public decimal Balance { get; set; }
    public bool IsActive { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Cashbox, CashboxDto>();
    }
}