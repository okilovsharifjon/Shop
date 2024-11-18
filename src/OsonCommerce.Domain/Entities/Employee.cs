namespace OsonCommerce.Domain.Entities
{
    public class Employee : User
    {
        public Guid Id { get; set; }
        public string Position { get; set; }
        public DateTime HireDate { get; set; }
        public bool IsActive { get; set; }
        public string? Department { get; set; }
        
    }
}               
