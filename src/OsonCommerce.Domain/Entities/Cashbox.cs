namespace OsonCommerce.Domain.Entities
{
    public class Cashbox
    {
        public Guid Id { get; set; }
        public Guid StoreBranchId { get; set; }
        public ICollection<Guid> ChashierIds { get; set; }
        public string Name { get; set; }
        public string Key { get; set; }
        public decimal Balance { get; set; }
        public bool IsActive { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public ICollection<Employee> Chashiers { get; set; }
        public StoreBranch StoreBranch { get; set; }
        public ICollection<CashboxOperation> CashboxOperations { get; set; }
    }
}
