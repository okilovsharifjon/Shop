

namespace CatalogService.Domain.Entities
{
    public class Cashbox
    {
        public Guid Id { get; set; }
        public Guid StoreBranchId { get; set; }
        public string Name { get; set; }
        public string Key { get; set; }
        public decimal Balance { get; set; }
        public bool IsActive { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public List<CashboxOperation> CashboxOperations { get; set; } = new List<CashboxOperation>();
    }
}
