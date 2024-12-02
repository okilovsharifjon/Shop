using MediatR;
using OsonCommerce.Application.Interfaces;
using OsonCommerce.Application.Common.Exceptions;
using OsonCommerce.Domain.Entities;
using OsonCommerce.Application.Interfaces.Repositories;

namespace OsonCommerce.Application.Features;

public class DeleteEmployeeCommandHandler(
    IEmployeeRepository repository, 
    IUnitOfWork unitOfWork
    ) : IRequestHandler<DeleteEmployeeCommand>
{
    private readonly IEmployeeRepository _repository = repository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        if(request.Id == Guid.Empty)
            throw new EmptyRequestException("Id is required");

        await _repository.DeleteAsync(request.Id, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}