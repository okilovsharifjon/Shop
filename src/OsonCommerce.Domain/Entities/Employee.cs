namespace OsonCommerce.Domain.Entities;

public class Employee : User
{
    public string Position { get; set; }
    public DateTime HireDate { get; set; }
    public bool IsActive { get; set; }
    public string? Department { get; set; }
    
}
           
