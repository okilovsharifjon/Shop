using System.Threading;
using System.Threading.Tasks;
using MediatR;
using CatalogService.Domain.Entities;
using CatalogService.Application.Exceptions;
using FluentValidation;
using CatalogService.Application.Interfaces;

namespace CatalogService.Application.UseCases
{
    public class UpdateCashboxCommandHandler : IRequestHandler<UpdateCashboxCommand>
    {
        private readonly IRepository<Cashbox> _repository;
        private readonly IValidator<UpdateCashboxCommand> _validator;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCashboxCommandHandler(IRepository<Cashbox> repository, IValidator<UpdateCashboxCommand> validator, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _validator = validator;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateCashboxCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAsync(request, cancellationToken);
            var cashbox = await _repository.GetByIdAsync(request.Id, cancellationToken);
            if (cashbox == null)
            {
                throw new NotFoundException("Cashbox not found");
            }

            cashbox.Name = request.Name;
            cashbox.Key = request.Key;
            cashbox.IsActive = request.IsActive;

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}

