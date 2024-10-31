using MediatR;

namespace OsonCommerce.Application.Features
{
    public class DeleteProductCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}