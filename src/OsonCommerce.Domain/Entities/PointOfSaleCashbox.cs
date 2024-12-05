namespace OsonCommerce.Domain.Entities
{
    public class StoreBranchCashbox : Cashbox
    {
        public Guid StoreBranchId { get; set; }
        public ICollection<Guid> CashierIds { get; set; }
        public ICollection<Employee> Cashiers { get; set; }
        public StoreBranch StoreBranch { get; set; }
    }
}