using MediatR;
using FluentValidation;
using OsonCommerce.Application.Interfaces;
using OsonCommerce.Domain.Entities;
using OsonCommerce.Application.Exceptions;
using OsonCommerce.Application.Interfaces.Repositories;

namespace OsonCommerce.Application.Features;

public class UpdateStoreBranchCommandHandler(
    IRepository<StoreBranch> repository, 
    IUnitOfWork unitOfWork, 
    IValidator<UpdateStoreBranchCommand> validator
    ) : IRequestHandler<UpdateStoreBranchCommand>
{
    private readonly IRepository<StoreBranch> _repository = repository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IValidator<UpdateStoreBranchCommand> _validator = validator;

    public async Task Handle(UpdateStoreBranchCommand request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(request, cancellationToken);
        var storeBranch = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (storeBranch == null)
        {
            throw new NotFoundException("StoreBranch not found");
        }

        storeBranch.Name = request.Name;
        storeBranch.ManagerIds = request.ManagerIds;
        storeBranch.Address = request.Address;
        storeBranch.PhoneNumber = request.PhoneNumber;
        storeBranch.OperatingHours = request.OperatingHours;
        storeBranch.Email = request.Email;
        storeBranch.IsActive = request.IsActive;

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
} 