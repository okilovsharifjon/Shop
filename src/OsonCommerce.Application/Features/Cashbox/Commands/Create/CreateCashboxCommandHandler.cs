using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OsonCommerce.Domain.Entities;
using FluentValidation;
using OsonCommerce.Application.Interfaces;

namespace OsonCommerce.Application.Features
{
    public class CreateCashboxCommandHandler : IRequestHandler<CreateCashboxCommand, Guid>
    {
        private readonly IRepository<Cashbox> _repository;
        private readonly IValidator<CreateCashboxCommand> _validator;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCashboxCommandHandler(IRepository<Cashbox> repository, IValidator<CreateCashboxCommand> validator, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _validator = validator;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateCashboxCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAsync(request, cancellationToken);

            var cashbox = new Cashbox
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Balance = request.Balance,
                Key = request.Key,
                IsActive = true,
                LastUpdatedDate = DateTime.UtcNow
            };

            await _repository.CreateAsync(cashbox, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return cashbox.Id;
        }


    }
}

