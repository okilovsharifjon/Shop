using MediatR;
using AutoMapper;
using OsonCommerce.Domain.Entities;
using OsonCommerce.Application.Interfaces;


namespace OsonCommerce.Application.Features;

public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, List<EmployeeDto>>
{
    private readonly IRepository<Employee> _repository;
    private readonly IMapper _mapper;
    public GetAllEmployeesQueryHandler(IRepository<Employee> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<EmployeeDto>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
    {
        var employees = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<List<EmployeeDto>>(employees);
    }
}