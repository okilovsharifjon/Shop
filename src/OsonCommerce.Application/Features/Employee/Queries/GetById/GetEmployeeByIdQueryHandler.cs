using MediatR;
using AutoMapper;
using OsonCommerce.Application.Common.Exceptions;
using OsonCommerce.Domain.Entities;
using OsonCommerce.Application.Interfaces.Repositories;


namespace OsonCommerce.Application.Features;

public class GetEmployeeByIdQueryHandler(
    IEmployeeRepository repository, 
    IMapper mapper) : IRequestHandler<GetEmployeeByIdQuery, EmployeeDto>
{
    private readonly IEmployeeRepository _repository = repository;
    private readonly IMapper _mapper = mapper;

    public async Task<EmployeeDto> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
    {
        var employee = await _repository.GetByIdAsNoTrackingAsync(request.Id, cancellationToken);
        if (employee == null)
        {
            throw new NotFoundException("Employee not found");
        }
        return _mapper.Map<EmployeeDto>(employee);
    }
}