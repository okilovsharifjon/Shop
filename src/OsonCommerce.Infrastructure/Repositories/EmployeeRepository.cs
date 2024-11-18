using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OsonCommerce.Application.Interfaces.Repositories;
using OsonCommerce.Domain.Entities;

namespace OsonCommerce.Infrastructure.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        private readonly OsonCommerceDbContext _context;

        public EmployeeRepository(OsonCommerceDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Employee> GetByEmail(string email, CancellationToken cancellationToken)
        {
            return await _context.Employees.AsNoTracking().FirstOrDefaultAsync(e => e.Email.Equals(email), cancellationToken);
        }
    }
}
