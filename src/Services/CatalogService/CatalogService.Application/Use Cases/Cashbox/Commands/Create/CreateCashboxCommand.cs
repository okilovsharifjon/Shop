using MediatR;

namespace CatalogService.Application.UseCases
{
    public class CreateCashboxCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Key { get; set; }
        public decimal Balance { get; set; }
        public bool IsActive { get; set; }
    }
}

