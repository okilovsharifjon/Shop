﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsonCommerce.Application.Features;

public class RegisterEmployeeCommand : IRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Position { get; set; }
    public DateTime HireDate { get; set; }
    public string? Department { get; set; }
    public string Password { get; set; }
}
