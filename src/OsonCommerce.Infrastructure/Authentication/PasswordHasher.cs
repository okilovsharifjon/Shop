using BCrypt.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OsonCommerce.Application.Interfaces;

namespace OsonCommerce.Infrastructure.Authentication
{
    public class PasswordHasher : IPasswordHasher
    {
        public string Generate(string password) =>
            BCrypt.Net.BCrypt.EnhancedHashPassword(password);

        public bool Verify(string password, string hashedPassword) =>
            BCrypt.Net.BCrypt.EnhancedVerify(password, hashedPassword);
    }
}
