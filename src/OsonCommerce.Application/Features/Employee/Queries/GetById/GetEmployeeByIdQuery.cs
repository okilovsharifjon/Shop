using MediatR;

namespace OsonCommerce.Application.Features;

public class GetEmployeeByIdQuery : IRequest<EmployeeDto>
{
    public Guid Id { get; set; }
}