using MediatR;
using FluentValidation;
using OsonCommerce.Application.Interfaces;
using OsonCommerce.Domain.Entities;
using OsonCommerce.Application.Exceptions;

namespace OsonCommerce.Application.Features;

public class UpdateStoreBranchCommandHandler : IRequestHandler<UpdateStoreBranchCommand>
{
    private readonly IRepository<StoreBranch> _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<UpdateStoreBranchCommand> _validator;

    public UpdateStoreBranchCommandHandler(IRepository<StoreBranch> repository, IUnitOfWork unitOfWork, IValidator<UpdateStoreBranchCommand> validator)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _validator = validator;
    }

    public async Task Handle(UpdateStoreBranchCommand request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(request, cancellationToken);
        var storeBranch = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (storeBranch == null)
        {
            throw new NotFoundException("StoreBranch not found");
        }

        storeBranch.Name = request.Name;
        storeBranch.Location = request.Location;
        storeBranch.Manager = request.Manager;
        storeBranch.IsActive = request.IsActive;

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
} 