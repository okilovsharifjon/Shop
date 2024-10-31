using CatalogService.Domain.Entities;
using MediatR;
using FluentValidation;
using OsonCommerce.Application.Interfaces;


namespace OsonCommerce.Application.Features;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
{
    private readonly IRepository<Category> _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<DeleteCategoryCommand> _validator;

    public DeleteCategoryCommandHandler(IRepository<Category> repository, IUnitOfWork unitOfWork, IValidator<DeleteCategoryCommand> validator)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _validator = validator;
    }

    public async Task Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(request, cancellationToken);
        await _repository.DeleteAsync(request.Id, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}