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

namespace OsonCommerce.Application.Features
{
    public class RegisterEmployeeCommandHandler : IRequestHandler<RegisterEmployeeCommand>
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly IRepository<Employee> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtProvider _jwtProvider;
        private readonly IValidator<RegisterEmployeeCommand> _validator;

        public RegisterEmployeeCommandHandler(
            IPasswordHasher passwordHasher, IRepository<Employee> repository, 
            IUnitOfWork unitOfWork, IValidator<RegisterEmployeeCommand> validator)
        {
            _passwordHasher = passwordHasher;
            _repository = repository;
            _unitOfWork = unitOfWork;   
            _validator = validator;
        }
        public async Task Handle(RegisterEmployeeCommand request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrowAsync(request, cancellationToken);
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
}
