using OsonCommerce.Domain.Entities;
using MediatR;
using FluentValidation;
using OsonCommerce.Application.Interfaces;

namespace OsonCommerce.Application.Features;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Guid>
{
    private readonly IRepository<Category> _repository;
    private readonly IValidator<CreateCategoryCommand> _validator;
    private readonly IUnitOfWork _unitOfWork;

    public CreateCategoryCommandHandler(IRepository<Category> repository, IValidator<CreateCategoryCommand> validator, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _validator = validator;
        _unitOfWork = unitOfWork;
    }

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