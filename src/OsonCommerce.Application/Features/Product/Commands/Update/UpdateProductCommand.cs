using MediatR;

namespace OsonCommerce.Application.Features
{
    public class UpdateProductCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? CategoryId { get; set; }
        public string ImageName { get; set; }
        public string Description { get; set; }
        public decimal Weight { get; set; }
    }
}
