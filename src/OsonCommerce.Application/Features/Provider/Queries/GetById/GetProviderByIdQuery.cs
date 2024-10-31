using MediatR;

namespace OsonCommerce.Application.Features
{
    public class GetProviderByIdQuery : IRequest<ProviderDto>
    {
        public Guid Id { get; set; }
    }
}

