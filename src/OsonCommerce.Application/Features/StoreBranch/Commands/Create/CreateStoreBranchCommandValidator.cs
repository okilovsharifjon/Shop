using FluentValidation;

namespace OsonCommerce.Application.Features;

public class CreateStoreBranchCommandValidator : AbstractValidator<CreateStoreBranchCommand>
{
    public CreateStoreBranchCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");

        RuleFor(x => x.ManagerIds)
            .NotEmpty().WithMessage("At least one manager ID is required.");

        RuleFor(x => x.Address)
            .NotEmpty().WithMessage("Address is required.");

        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("Phone number is required.")
            .Matches(@"^\+?[1-9]\d{1,14}$").WithMessage("Phone number is not valid.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Email is not valid.");

        RuleFor(x => x.OperatingHours)
            .NotEmpty().WithMessage("Operating hours are required.");
    }
} 