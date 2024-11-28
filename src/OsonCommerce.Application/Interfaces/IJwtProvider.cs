using OsonCommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsonCommerce.Application.Interfaces;

public interface IJwtProvider
{
    //string GenerateToken(Employee employee);
    //string GenerateToken(Customer customer);
    Task<string> GenerateToken(User user, CancellationToken cancellationToken);
}
