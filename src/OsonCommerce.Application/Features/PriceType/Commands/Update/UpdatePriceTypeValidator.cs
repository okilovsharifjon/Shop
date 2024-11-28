using FluentValidation;

namespace OsonCommerce.Application.Features;

public class UpdatePriceTypeCommandValidator : AbstractValidator<UpdatePriceTypeCommand>
{
    public UpdatePriceTypeCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.")
            .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");
        RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required.")
            .MaximumLength(255).WithMessage("Description must not exceed 255 characters.");
    }
}