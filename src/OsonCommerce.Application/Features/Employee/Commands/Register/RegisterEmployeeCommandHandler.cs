using MediatR;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OsonCommerce.Application.Interfaces;
using OsonCommerce.Domain.Entities;
using OsonCommerce.Application.Interfaces.Repositories;
using OsonCommerce.Application.Exceptions;

namespace OsonCommerce.Application.Features;

public class RegisterEmployeeCommandHandler(
    IPasswordHasher passwordHasher, 
    IEmployeeRepository repository,
    IUnitOfWork unitOfWork, 
    IValidator<RegisterEmployeeCommand> validator
    ) : IRequestHandler<RegisterEmployeeCommand>
{
    private readonly IPasswordHasher _passwordHasher = passwordHasher;
    private readonly IEmployeeRepository _repository = repository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IValidator<RegisterEmployeeCommand> _validator = validator;

    public async Task Handle(RegisterEmployeeCommand request, CancellationToken cancellationToken)
    {
        _validator.ValidateAndThrowAsync(request, cancellationToken);

        var existingEmployee = await _repository.GetByEmailAsync(request.Email, cancellationToken);
        if (existingEmployee != null)
        {
            throw new ExistingDataException($"Employee with '{existingEmployee.Email}' email already exists!");
        }

        var hashedPassword = _passwordHasher.Generate(request.Password);
        
        var employee = new Employee
    {
        Id = Guid.NewGuid(),
        FirstName = request.FirstName,
        LastName = request.LastName,
        PhoneNumber = request.PhoneNumber,
        Email = request.Email,
        Position = request.Position,
        Department = request.Department,
        Password = hashedPassword
    };

    await _repository.CreateAsync(employee, cancellationToken);
    await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
