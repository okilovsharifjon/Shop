using MediatR;
using FluentValidation;
using OsonCommerce.Application.Interfaces;

namespace OsonCommerce.Application.Features;

public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Guid>
{
    private readonly IRepository<Employee> _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<CreateEmployeeCommand> _validator;

    public CreateEmployeeCommandHandler(IRepository<Employee> repository, IUnitOfWork unitOfWork, IValidator<CreateEmployeeCommand> validator)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _validator = validator;
    }

    public async Task<Guid> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(request, cancellationToken);
        var employee = new Employee
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
        };

        await _repository.CreateAsync(employee, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return employee.Id;
    }
}