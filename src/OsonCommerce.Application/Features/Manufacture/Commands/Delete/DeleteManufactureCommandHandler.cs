using MediatR;
using FluentValidation;
using OsonCommerce.Domain.Entities;
using OsonCommerce.Application.Interfaces;
using OsonCommerce.Application.Exceptions;
using OsonCommerce.Application.Interfaces.Repositories;

namespace OsonCommerce.Application.Features;

public class DeleteManufactureCommandHandler : IRequestHandler<DeleteManufactureCommand>
{
    private readonly IRepository<Manufacture> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteManufactureCommandHandler(IRepository<Manufacture> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteManufactureCommand request, CancellationToken cancellationToken)
    {
        if (request.Id == Guid.Empty)
        {
            throw new EmptyRequestException("Id is required");
        }

        await _repository.DeleteAsync(request.Id, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
} 