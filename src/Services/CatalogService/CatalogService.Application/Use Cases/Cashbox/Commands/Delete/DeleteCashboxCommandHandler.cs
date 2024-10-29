using System.Threading;
using System.Threading.Tasks;
using MediatR;
using CatalogService.Domain.Entities;
using FluentValidation;
using CatalogService.Application.Interfaces;

namespace CatalogService.Application.UseCases
{
    public class DeleteCashboxCommandHandler : IRequestHandler<DeleteCashboxCommand>
    {
        private readonly IRepository<Cashbox> _repository;
        private readonly IValidator<DeleteCashboxCommand> _validator;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCashboxCommandHandler(IRepository<Cashbox> repository, IValidator<DeleteCashboxCommand> validator, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _validator = validator;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteCashboxCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAsync(request, cancellationToken);
            await _repository.DeleteAsync(request.Id, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}

