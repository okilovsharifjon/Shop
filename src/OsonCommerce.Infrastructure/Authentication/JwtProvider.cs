using OsonCommerce.Domain.Entities;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using OsonCommerce.Application.Interfaces;
using OsonCommerce.Application.Interfaces.Repositories;

namespace OsonCommerce.Infrastructure.Authentication;

public class JwtProvider(
    IOptions<JwtOptions> options,
    IEmployeeRepository repository, 
    IRepository<Role> roleRepository
    ) : IJwtProvider 
{
    private readonly JwtOptions _options = options.Value;
    private readonly IEmployeeRepository _employeeRepository = repository;
    private readonly IRepository<Role> _roleRepository = roleRepository;

    public async Task<string> GenerateToken(User user, CancellationToken cancellationToken)
    {
        if (user == null) throw new ArgumentNullException(nameof(user));

        var id = user.Id;
        var name = user.FirstName;
        var roles = user.UserRoles;

        if(user is Employee employee)
        {
            employee = await _employeeRepository.GetByIdAsync(id, cancellationToken);
            id = employee.Id;
            roles = employee.UserRoles;
        }
        else if(user is Customer customer)
        {
            id = customer.Id;
            //roles = customer.UserRoles;
        }

        var claims = new List<Claim>
            {
            new(ClaimTypes.NameIdentifier, id.ToString()),
            new(ClaimTypes.Name, name.ToString())
            };

        foreach (var roleId in roles.Select(r => r.RoleId))
        {
            var role = await _roleRepository.GetByIdAsync(roleId, cancellationToken);
            claims.Add(new Claim(ClaimTypes.Role, role.Name));
        }

        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey)),
            SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            claims: claims,
            signingCredentials: signingCredentials,
            expires: DateTime.UtcNow.AddHours(_options.ExpireHours));

        var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);
        return tokenValue;
    }
}
