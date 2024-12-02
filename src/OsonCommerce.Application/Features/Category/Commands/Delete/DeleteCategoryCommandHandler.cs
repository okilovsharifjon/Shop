using OsonCommerce.Domain.Entities;
using MediatR;
using OsonCommerce.Application.Interfaces;
using OsonCommerce.Application.Common.Exceptions;
using OsonCommerce.Application.Interfaces.Repositories;


namespace OsonCommerce.Application.Features;

public class DeleteCategoryCommandHandler(
    IRepository<Category> repository, 
    IUnitOfWork unitOfWork
    ) : IRequestHandler<DeleteCategoryCommand>
{
    private readonly IRepository<Category> _repository = repository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        if (request.Id == Guid.Empty)
        {
            throw new EmptyRequestException("Id is required");
        }

        await _repository.DeleteAsync(request.Id, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}