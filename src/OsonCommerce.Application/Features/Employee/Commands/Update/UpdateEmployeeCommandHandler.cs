using MediatR;
using OsonCommerce.Domain.Entities;
using FluentValidation;
using OsonCommerce.Application.Interfaces;
using OsonCommerce.Application.Exceptions;

namespace OsonCommerce.Application.Features;

public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand>
{
    private readonly IRepository<Employee> _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<UpdateEmployeeCommand> _validator;

    public UpdateEmployeeCommandHandler(IRepository<Employee> repository, IUnitOfWork unitOfWork, IValidator<UpdateEmployeeCommand> validator)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _validator = validator;
    }

    public async Task Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(request, cancellationToken);
        var employee = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (employee == null)
        {
            throw new NotFoundException("Employee not found");
        }

        employee.FirstName = request.FirstName;
        employee.LastName = request.LastName;
        employee.Email = request.Email;
        employee.PhoneNumber = request.PhoneNumber;
        employee.Position = request.Position;
        employee.HireDate = request.HireDate;
        employee.IsActive = request.IsActive;
        employee.Department = request.Department;

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}