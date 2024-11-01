using MediatR;
using OsonCommerce.Application.Interfaces;

namespace OsonCommerce.Application.Features;

public class DeleteEmployeeCommand : IRequest
{
    public Guid Id { get; set; }
}