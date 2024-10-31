namespace OsonCommerce.Domain.Entities
{
    public class Employee
    {
        public Guid Id { get; set; }
        public Guid? StoreBranchId { get; set; }
        public StoreBranch? StoreBranch { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Position { get; set; }
        public DateTime HireDate { get; set; }
        public bool IsActive { get; set; }
        public string Department { get; set; }
        
    }
}
