using FluentValidation;

namespace OsonCommerce.Application.Features;

public class CreatePriceTypeCommandValidator : AbstractValidator<CreatePriceTypeCommand>
{
    public CreatePriceTypeCommandValidator()
    {
        RuleFor(command => command.Name)
            .NotEmpty().WithMessage("Name is required.")
            .Length(2, 100).WithMessage("Name must be between 2 and 100 characters.");
        
        RuleFor(command => command.Description)
            .NotEmpty().WithMessage("Description is required.")
            .MaximumLength(255).WithMessage("Description must not exceed 255 characters.");

    }
}
