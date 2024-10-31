using CatalogService.Domain.Entities;
using MediatR;
using OsonCommerce.Application.Interfaces;
using FluentValidation;

namespace OsonCommerce.Application.Features;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
{
    private readonly IRepository<Category> _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<UpdateCategoryCommand> _validator;

    public UpdateCategoryCommandHandler(IRepository<Category> repository, IUnitOfWork unitOfWork, IValidator<UpdateCategoryCommand> validator)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _validator = validator;
    }

    public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(request, cancellationToken);
        var category = await _repository.GetByIdAsync(request.Id, cancellationToken);
        category.Name = request.Name;
        category.Description = request.Description;
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}