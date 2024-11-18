using MediatR;
using AutoMapper;
using OsonCommerce.Application.Interfaces;
using OsonCommerce.Domain.Entities;

namespace OsonCommerce.Application.Features;

public class UpdateEmployeeCommand : IRequest
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Position { get; set; }
    public DateTime HireDate { get; set; }
    public bool IsActive { get; set; }
    public string? Department { get; set; }
}
