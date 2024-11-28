using FluentValidation;

namespace OsonCommerce.Application.Features;

public class UpdateProductAttributeCommandValidator : AbstractValidator<UpdateProductAttributeCommand>
{
    public UpdateProductAttributeCommandValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty().WithMessage("Product Attribute ID is required.");

        RuleFor(command => command.Name)
            .NotEmpty().WithMessage("Attribute Name is required.");

    }
}
