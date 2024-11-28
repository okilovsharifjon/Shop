using MediatR;
using FluentValidation;
using OsonCommerce.Application.Interfaces;
using OsonCommerce.Domain.Entities;
using OsonCommerce.Application.Interfaces.Repositories;

namespace OsonCommerce.Application.Features;

public class CreateEmployeeCommandHandler(
    IEmployeeRepository repository, 
    IUnitOfWork unitOfWork, 
    IValidator<CreateEmployeeCommand> validator
    ) : IRequestHandler<CreateEmployeeCommand, Guid>
{
    private readonly IEmployeeRepository _repository = repository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IValidator<CreateEmployeeCommand> _validator = validator;

    public async Task<Guid> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(request, cancellationToken);
        
        var employee = new Employee
        {
            Id = Guid.NewGuid(),
            FirstName = request.FirstName,
            LastName = request.LastName,
            PhoneNumber = request.PhoneNumber,
            Email = request.Email,
            Position = request.Position,
            Department = request.Department,
            IsActive = request.IsActive,
        };

        await _repository.CreateAsync(employee, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return employee.Id;
    }
}