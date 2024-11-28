namespace OsonCommerce.Domain.Entities;

public class Provider
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string ContactInfo { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; }
}
