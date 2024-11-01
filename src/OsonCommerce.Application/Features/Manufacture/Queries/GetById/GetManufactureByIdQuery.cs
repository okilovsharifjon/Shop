using MediatR;
using AutoMapper;
using OsonCommerce.Domain.Entities;

namespace OsonCommerce.Application.Features;

public class GetManufactureByIdQuery : IRequest<ManufactureDto>
{
    public Guid Id { get; set; }
}