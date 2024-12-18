using MediatR;
using FluentValidation;
using OsonCommerce.Domain.Entities;
using OsonCommerce.Application.Interfaces;
using OsonCommerce.Application.Common.Exceptions;
using OsonCommerce.Application.Interfaces.Repositories;

namespace OsonCommerce.Application.Features;

public class UpdateManufactureCommandHandler(
    IRepository<Manufacture> repository, 
    IUnitOfWork unitOfWork, 
    IValidator<UpdateManufactureCommand> validator
    ) : IRequestHandler<UpdateManufactureCommand>
{
    private readonly IRepository<Manufacture> _repository = repository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IValidator<UpdateManufactureCommand> _validator = validator;

    public async Task Handle(UpdateManufactureCommand request, CancellationToken cancellationToken)
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
    }
}