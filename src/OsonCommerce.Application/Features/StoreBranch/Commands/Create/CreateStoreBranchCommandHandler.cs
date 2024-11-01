using MediatR;
using FluentValidation;
using OsonCommerce.Application.Interfaces;
using OsonCommerce.Domain.Entities;

namespace OsonCommerce.Application.Features;

public class CreateStoreBranchCommandHandler : IRequestHandler<CreateStoreBranchCommand, Guid>
{
    private readonly IRepository<StoreBranch> _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<CreateStoreBranchCommand> _validator;

    public CreateStoreBranchCommandHandler(IRepository<StoreBranch> repository, IUnitOfWork unitOfWork, IValidator<CreateStoreBranchCommand> validator)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _validator = validator;
    }

    public async Task<Guid> Handle(CreateStoreBranchCommand request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(request, cancellationToken);
        // Implement the logic for creating a store branch
        // ...
        return Guid.NewGuid();
    }
} 