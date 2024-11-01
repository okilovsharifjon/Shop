using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OsonCommerce.Application.Interfaces;
using OsonCommerce.Domain.Entities;
using OsonCommerce.Application.Exceptions;
namespace OsonCommerce.Application.Features
{
    public class DeleteProviderCommandHandler : IRequestHandler<DeleteProviderCommand>
    {
        private readonly IRepository<Provider> _repository;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteProviderCommandHandler(IRepository<Provider> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteProviderCommand request, CancellationToken cancellationToken)
        {
            if (request.Id == Guid.Empty)
                throw new EmptyRequestException("Id is required");

            await _repository.DeleteAsync(request.Id, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}

