using System.Threading;
using System.Threading.Tasks;
using MediatR;
using FluentValidation;
using CatalogService.Application.Interfaces;
using CatalogService.Domain.Entities;

namespace CatalogService.Application.UseCases
{
    public class CreateProviderCommandHandler : IRequestHandler<CreateProviderCommand, Guid>
    {
        private readonly IRepository<Provider> _repository;
        private readonly IValidator<CreateProviderCommand> _validator;
        private readonly IUnitOfWork _unitOfWork;   

        public CreateProviderCommandHandler(IRepository<Provider> repository, IValidator<CreateProviderCommand> validator, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _validator = validator;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateProviderCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAsync(request, cancellationToken);

            var provider = new Provider
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                ContactInfo = request.ContactInfo,
                Address = request.Address,
                Email = request.Email,
                Description = request.Description,
                IsActive = request.IsActive
            };

            await _repository.CreateAsync(provider, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return provider.Id;
        }
    }
}

