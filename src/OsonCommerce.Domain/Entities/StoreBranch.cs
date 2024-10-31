namespace OsonCommerce.Domain.Entities
{
    public class StoreBranch
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid ManagerId { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public string OperatingHours { get; set; }
        public int NumberOfEmployees { get; set; }
        public Employee Manager { get; set; }
    }
}