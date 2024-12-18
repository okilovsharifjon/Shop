﻿namespace OsonCommerce.Domain.Entities;

public abstract class User
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
    public DateTime RegistrationDate { get; set; }
    public ICollection<int> Roles {  get; set; }
}
