using MediatR;

namespace OsonCommerce.Application.Features;

public class GetAllEmployeesQuery : IRequest<List<EmployeeDto>>
{ }