using MediatR;
using OsonCommerce.Application.Interfaces;
using OsonCommerce.Application.Exceptions;
using OsonCommerce.Domain.Entities;

namespace OsonCommerce.Application.Features;

public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand>
{
    private readonly IRepository<Employee> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteEmployeeCommandHandler(IRepository<Employee> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        if(request.Id == Guid.Empty)
            throw new EmptyRequestException("Id is required");

        await _repository.DeleteAsync(request.Id, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}