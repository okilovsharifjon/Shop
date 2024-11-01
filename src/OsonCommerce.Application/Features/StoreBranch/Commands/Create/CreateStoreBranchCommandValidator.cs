using FluentValidation;

namespace OsonCommerce.Application.Features;

public class CreateStoreBranchCommandValidator : AbstractValidator<CreateStoreBranchCommand>
{
    public CreateStoreBranchCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");

        RuleFor(x => x.Location)
            .NotEmpty().WithMessage("Location is required.");
    }
} 