using OsonCommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using OsonCommerce.Application.Interfaces;

namespace OsonCommerce.Infrastructure.Authentication
{
    public class JwtProvider : IJwtProvider 
    {
        private readonly JwtOptions _options;

        public JwtProvider(IOptions<JwtOptions> options)
        {
            _options = options.Value;
        }
        public string GenerateToken(User user)
        {
            Claim[] claims = { new("userId", user.Id.ToString()) };

            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey)),
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                signingCredentials: signingCredentials,
                expires: DateTime.UtcNow.AddHours(_options.ExpireHours));

            var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenValue;
        }
    }
}
