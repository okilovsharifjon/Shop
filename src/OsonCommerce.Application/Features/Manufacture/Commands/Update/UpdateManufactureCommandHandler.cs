using MediatR;
using FluentValidation;
using OsonCommerce.Domain.Entities;
using OsonCommerce.Application.Interfaces;
using OsonCommerce.Application.Exceptions;

namespace OsonCommerce.Application.Features;

public class UpdateManufactureCommandHandler : IRequestHandler<UpdateManufactureCommand>
{
    private readonly IRepository<Manufacture> _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<UpdateManufactureCommand> _validator;

    public UpdateManufactureCommandHandler(IRepository<Manufacture> repository, IUnitOfWork unitOfWork, IValidator<UpdateManufactureCommand> validator)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _validator = validator;
    }

    public async Task<Unit> Handle(UpdateManufactureCommand request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAsync(request, cancellationToken);
        var manufacture = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (manufacture == null)
        {
            throw new NotFoundException("Manufacture not found");
        }

        manufacture.Name = request.Name;
        manufacture.Description = request.Description;
        manufacture.LogoName = request.LogoName;
        manufacture.WebsiteUrl = request.WebsiteUrl;
        manufacture.CountryOfOrigin = request.CountryOfOrigin;
        manufacture.IsActive = request.IsActive;

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}