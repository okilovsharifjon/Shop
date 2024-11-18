using MediatR;
using AutoMapper;
using OsonCommerce.Application.Exceptions;
using OsonCommerce.Domain.Entities;
using OsonCommerce.Application.Interfaces.Repositories;


namespace OsonCommerce.Application.Features;

public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, EmployeeDto>
{
    private readonly IRepository<Employee> _repository;
    private readonly IMapper _mapper;

    public GetEmployeeByIdQueryHandler(IRepository<Employee> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;   
    }

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