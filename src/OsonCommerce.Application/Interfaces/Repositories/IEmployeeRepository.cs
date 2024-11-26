using OsonCommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsonCommerce.Application.Interfaces.Repositories
{
    public interface IEmployeeRepository : IRepository<Employee>    
    {
        Task<Employee> GetByEmailAsync(string email, CancellationToken cancellationToken);


    }
}
