using MediatR;
using OsonCommerce.Domain.Entities;

namespace OsonCommerce.Application.Features;

public class DeleteProductInStockCommand : IRequest
{
    public Guid Id { get; set; }
}