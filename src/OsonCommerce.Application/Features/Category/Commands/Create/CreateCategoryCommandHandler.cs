using OsonCommerce.Domain.Entities;
using MediatR;
using FluentValidation;
using OsonCommerce.Application.Interfaces;
using OsonCommerce.Application.Interfaces.Repositories;

namespace OsonCommerce.Application.Features;

public class CreateCategoryCommandHandler(
    IRepository<Category> repository, 
    IValidator<CreateCategoryCommand> validator, 
    IUnitOfWork unitOfWork
    ) : IRequestHandler<CreateCategoryCommand, Guid>
{
    private readonly IRepository<Category> _repository = repository;
    private readonly IValidator<CreateCategoryCommand> _validator = validator;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Guid> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(request, cancellationToken);
        var category = new Category
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Description = request.Description
        };
        await _repository.CreateAsync(category, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return category.Id;
    }
}