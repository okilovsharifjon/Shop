using System.Threading;
using System.Threading.Tasks;
using MediatR;
using FluentValidation;
using CatalogService.Application.Interfaces;
using CatalogService.Domain.Entities;

namespace CatalogService.Application.UseCases
{
    public class DeleteProviderCommandHandler : IRequestHandler<DeleteProviderCommand>
    {
        private readonly IRepository<Provider> _repository;
        private readonly IValidator<DeleteProviderCommand> _validator;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteProviderCommandHandler(IRepository<Provider> repository, IValidator<DeleteProviderCommand> validator, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _validator = validator;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteProviderCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAsync(request, cancellationToken);
            await _repository.DeleteAsync(request.Id, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}

