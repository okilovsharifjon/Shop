namespace OsonCommerce.Domain.Entities
{
    public class CashboxOperation
    {
        public Guid Id { get; set; }
        public Guid CashboxId { get; set; }
        public Guid EmployeeId { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; } 
        public DateTime Time { get; set; }
        public string Description { get; set; }
        public int TransactionType { get; set; }
        public int TransactionStatus { get; set; }
        public Employee Employee { get; set; }
        public Cashbox Cashbox { get; set; }
    }
}