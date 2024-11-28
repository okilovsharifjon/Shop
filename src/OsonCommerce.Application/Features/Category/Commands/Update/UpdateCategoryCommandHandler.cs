using OsonCommerce.Domain.Entities;
using MediatR;
using OsonCommerce.Application.Interfaces;
using FluentValidation;
using OsonCommerce.Application.Interfaces.Repositories;

namespace OsonCommerce.Application.Features;

public class UpdateCategoryCommandHandler(
    IRepository<Category> repository, 
    IUnitOfWork unitOfWork, 
    IValidator<UpdateCategoryCommand> validator
    ) : IRequestHandler<UpdateCategoryCommand>
{
    private readonly IRepository<Category> _repository = repository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IValidator<UpdateCategoryCommand> _validator = validator;

    public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(request, cancellationToken);
        var category = await _repository.GetByIdAsync(request.Id, cancellationToken);
        category.Name = request.Name;
        category.Description = request.Description;
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}