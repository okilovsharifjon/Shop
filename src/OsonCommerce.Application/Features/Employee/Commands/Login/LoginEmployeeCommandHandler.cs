using MediatR;
using FluentValidation;
using OsonCommerce.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OsonCommerce.Domain.Entities;
using System.Reflection.Metadata;
using OsonCommerce.Application.Interfaces.Repositories;

namespace OsonCommerce.Application.Features
{
    public class LoginEmployeeCommandHandler : IRequestHandler<LoginEmployeeCommand, string>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IJwtProvider _jwtProvider;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IValidator<LoginEmployeeCommand> _validator;

        public LoginEmployeeCommandHandler(
            IEmployeeRepository employeeRepository, IValidator<LoginEmployeeCommand> validator,
            IJwtProvider jwtProvider, IPasswordHasher passwordHasher)
        {
            _employeeRepository = employeeRepository;
            _jwtProvider = jwtProvider;
            _passwordHasher = passwordHasher;
            _validator = validator;
        }

        public async Task<string> Handle(LoginEmployeeCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request, cancellationToken);
            var employee = await _employeeRepository.GetByEmailAsync(request.Email, cancellationToken);

            var result = _passwordHasher.Verify(request.Password, employee.Password);

            if(result == false)
            {
                throw new Exception("not authorized");
            }

            return await _jwtProvider.GenerateToken(employee, cancellationToken);
        }
    }
}
