using MediatR;
using OsonCommerce.Application.Exceptions;
using OsonCommerce.Domain.Entities;

namespace OsonCommerce.Application.Features;

public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, Employee>
{
    private readonly IRepository<Employee> _repository;

    public GetEmployeeByIdQueryHandler(IRepository<Employee> repository)
    {
        _repository = repository;
    }

    public async Task<Employee> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
    {
        var employee = await _repository.GetByIdAsNoTrackingAsync(request.Id, cancellationToken);
        if (employee == null)
        {
            throw new NotFoundException("Employee not found");
        }
        return employee;
    }
}