using OsonCommerce.Domain.Enums;
using MediatR;

namespace OsonCommerce.Application.Features
{
    public class CreateProductCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public Guid BrandId { get; set; }
        public Guid? CategoryId { get; set; }
        public Domain.Enums.Unit Unit { get; set; }
        public string ImageName { get; set; }
        public string Description { get; set; }
        public decimal Weight { get; set; }
        public DateTime ManufactureDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string SKU { get; set; }
    }
}
