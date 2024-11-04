using MediatR;

namespace OsonCommerce.Application.Features
{
    public class CreateCashboxCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public Guid StoreBranchId { get; set; }
        public List<Guid> ChashierIds { get; set; }
        public string Key { get; set; }
        public decimal Balance { get; set; }
        public bool IsActive { get; set; }
    }
}

