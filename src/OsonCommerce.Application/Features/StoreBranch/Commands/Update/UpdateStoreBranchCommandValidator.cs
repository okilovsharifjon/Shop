using FluentValidation;

namespace OsonCommerce.Application.Features;

public class UpdateStoreBranchCommandValidator : AbstractValidator<UpdateStoreBranchCommand>
{
    public UpdateStoreBranchCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");

        RuleFor(x => x.Location)
            .NotEmpty().WithMessage("Location is required.")
            .MaximumLength(200).WithMessage("Location must not exceed 200 characters.");

        RuleFor(x => x.Manager)
            .NotEmpty().WithMessage("Manager is required.")
            .MaximumLength(100).WithMessage("Manager must not exceed 100 characters.");

        RuleFor(x => x.IsActive)
            .NotNull().WithMessage("IsActive status is required.");
    }
} 