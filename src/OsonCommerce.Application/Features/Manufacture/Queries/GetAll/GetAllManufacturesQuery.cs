using MediatR;
using OsonCommerce.Domain.Entities;

namespace OsonCommerce.Application.Features;

public class GetAllManufacturesQuery : IRequest<List<Manufacture>>
{
}