namespace OsonCommerce.Domain.Entities;

public class Manufacture
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string LogoName { get; set; }
    public string WebsiteUrl { get; set; }
    public string CountryOfOrigin { get; set; }
    public bool IsActive { get; set; }
    
}
