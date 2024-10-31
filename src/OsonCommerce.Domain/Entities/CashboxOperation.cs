namespace OsonCommerce.Domain.Entities
{
    public class CashboxOperation
    {
        public Guid Id { get; set; }
        public Guid CashboxId { get; set; }
        public Guid EmployeeId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public TransactionType TransactionType { get; set; }
        public TransactionStatus Status { get; set; }
        public Employee Employee { get; set; }
        public Cashbox Cashbox { get; set; }
    }
}
