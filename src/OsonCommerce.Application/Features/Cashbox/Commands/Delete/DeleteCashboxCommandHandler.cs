using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OsonCommerce.Domain.Entities;
using OsonCommerce.Application.Interfaces;
using OsonCommerce.Application.Exceptions;

namespace OsonCommerce.Application.Features
{
    public class DeleteCashboxCommandHandler : IRequestHandler<DeleteCashboxCommand>
    {
        private readonly IRepository<Cashbox> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCashboxCommandHandler(IRepository<Cashbox> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteCashboxCommand request, CancellationToken cancellationToken)
        {
            if (request.Id == Guid.Empty)
            {
                throw new EmptyRequestException("Id is required");
            }

            await _repository.DeleteAsync(request.Id, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}

