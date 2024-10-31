using MediatR;

namespace OsonCommerce.Application.Features
{
    public class UpdateCashboxCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Key { get; set; }
        public bool IsActive { get; set; }
    }
}

