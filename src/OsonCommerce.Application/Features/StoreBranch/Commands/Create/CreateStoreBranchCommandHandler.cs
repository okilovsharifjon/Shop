using MediatR;
using FluentValidation;
using OsonCommerce.Application.Interfaces;
using OsonCommerce.Domain.Entities;
using OsonCommerce.Application.Interfaces.Repositories;

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
        var storeBranch = new StoreBranch
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Address = request.Address,
            PhoneNumber = request.PhoneNumber,
            Email = request.Email,
            IsActive = request.IsActive,
            OperatingHours = request.OperatingHours,
            ManagerIds = request.ManagerIds
        };
        await _repository.CreateAsync(storeBranch, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return storeBranch.Id;
    }
} 