using MediatR;
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

        public LoginEmployeeCommandHandler(IEmployeeRepository employeeRepository, 
            IJwtProvider jwtProvider, IPasswordHasher passwordHasher)
        {
            _employeeRepository = employeeRepository;
            _jwtProvider = jwtProvider;
            _passwordHasher = passwordHasher;
        }

        public async Task<string> Handle(LoginEmployeeCommand request, CancellationToken cancellationToken)
        {
            //todo: validator
            var employee = await _employeeRepository.GetByEmail(request.Email, cancellationToken);

            var result = _passwordHasher.Verify(request.Password, employee.Password);

            if(result == false)
            {
                throw new Exception("not authorized");
            }

            return _jwtProvider.GenerateToken(employee);
        }
    }
}
